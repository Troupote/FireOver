using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Target : MonoBehaviour
{
    public GameObject Plane; 
    private GameObject PlaneSelection; 
    private Vector3 realPosition;
    private bool Created = false; 
    private bool MachineCreated = false; 
    private bool isMouseOver = false; 
    private Camera mainCamera; 
    private Renderer renderer; 
    public Button MachineButton;
    public Button MachineButton1;
    public Button MachineButton2;
    public Button MachineButton3;

    public Inventory inventory;
    public GameObject[] Oven;
    public PlayerCollect PlayerCollect;
    private List<RecipesSO> RecipeS0Copy = new List<RecipesSO> (); 

    public Informations Informations;

    void Start()
    {
        mainCamera = Camera.main;
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isMouseOver && Input.GetMouseButtonDown(0))
        {
            
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // Déclare une variable de résultat de raycasting
            RaycastHit hit;

            // Teste si le rayon interagit avec le plan
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Plane"))
            {
                // Obtient la position de l'impact
                
                Vector3 mousePositionOnPlane = hit.point;

                if (!Created || realPosition == new Vector3((int)mousePositionOnPlane.x, mousePositionOnPlane.y + 0.3f, (int)mousePositionOnPlane.z))
                {
                    realPosition = new Vector3((int)mousePositionOnPlane.x, mousePositionOnPlane.y + 0.3f, (int)mousePositionOnPlane.z);
                    PlaneSelection = Instantiate(Plane, realPosition, Quaternion.identity);

                    Created = true;
                }
                else
                {
                    if (PlaneSelection != null)
                    {
                        Destroy(PlaneSelection);
                        Created = false;
                        
                    }
                    Created = false;
                    MachineCreated = false;
                }

               
            }
        }
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    public void MachineCreation()
    {
        if(MachineButton.IsInteractable())
        {
            MachineRecipe(0);
        }

    }
    public void MachineCreation1()
    {
        if(MachineButton.IsInteractable())
        {
            MachineRecipe(1);
            
        }

    }
    public void MachineCreation2()
    {
        if(MachineButton.IsInteractable())
        {
           MachineRecipe(2);
            
        }

    }
    public void MachineCreation3()
    {
        if(MachineButton.IsInteractable())
        {
            MachineRecipe(3);
        }

    }

    void MachineRecipe(int index)
    {
        MachineObjectSo MachineobjectWithSO = Oven[index].GetComponent<MachineObjectSo>();


            
        if(MachineobjectWithSO.myMachineScriptableObject.SOprefab.Length>0)
        {
            List<RecipesSO> InventoryCopy = new List<RecipesSO>(inventory.items);

            foreach(var elem in MachineobjectWithSO.myMachineScriptableObject.SOprefab)
            {
                if (InventoryCopy.Contains(elem))
                {
                    RecipeS0Copy.Add(elem);
                    InventoryCopy.Remove(elem);
                }

            }
            if(RecipeS0Copy.Count == MachineobjectWithSO.myMachineScriptableObject.SOprefab.Length)
            {
                if (Created && !MachineCreated)
                {
                    GameObject Machine = Instantiate(Oven[index], realPosition, Quaternion.identity);
                    MachineCreated = true;

                }

                foreach(var elem in RecipeS0Copy)
                {
                    inventory.RemoveItem(elem);
                                                    
                    
                    for(int k = 0;k < PlayerCollect.imageObjects.Length; k++)
                    {
                        int j = k;
                        if(PlayerCollect.imageObjects[k].GetComponent<Image>().sprite.name == elem. objectName)
                        {
                            while (j<5)
                            {
                                PlayerCollect.imageObjects[j].GetComponent<Image>().sprite = PlayerCollect.imageObjects[j+1].GetComponent<Image>().sprite;
                                j++;
                            }
                            if(j==5)
                            {
                            PlayerCollect.imageObjects[j].GetComponent<Image>().sprite = null;
                            PlayerCollect.i--;
                            }
                            break;
                        }
                        
                        
                    }
                }
            }
            else
            {
                Debug.Log("Manque de matériaux poutr les machines");
                Informations.Canvas.SetActive(true);
                Informations.StartCoroutine(Informations.ChangeSliderValueOverTime("Lack of Materials"));
            }    
            RecipeS0Copy.Clear();           
        }
            
    }
    
}
