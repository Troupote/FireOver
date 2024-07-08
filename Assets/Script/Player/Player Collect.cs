using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerCollect : MonoBehaviour
{
    public GameObject[] imageObjects;
    
    public Button ButtonE;
    public GameObject ButtonEO;

    public Button ButtonBuy;
    public GameObject ButtonBuyO;
    private bool IsClicked = false;
    private bool IsClickedBuy = false;

    public GameObject Menu;
    public Button ButtonMenu;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    [SerializeField] private Treatment protocoleiNSHALLAH;


    private int i = 0;
    public Inventory inventory;

    private RecipesSO[] RecipeScriptableObject;
    private List<BaseScriptableObject> RecipeS0Copy = new List<BaseScriptableObject> (); 

    private RecipesSO RecipeSo;

    void Start()
    {
        ButtonEO.SetActive(false);
        ButtonBuyO.SetActive(false);
        Menu.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        ObjectWithSO objectWithSO = other.GetComponent<ObjectWithSO>();
        if (objectWithSO != null)
        {
            BaseScriptableObject scriptableObject = objectWithSO.myScriptableObject;
            
            if ( scriptableObject.objectName.Length > 0 )
            {

                ButtonEO.SetActive(true);

                if (IsClicked)
                {
                    IsClicked = false;

                    if (i < imageObjects.Length)
                    {
                        imageObjects[i].GetComponent<Image>().sprite = scriptableObject.ObjectImage;
                        inventory.AddItem(scriptableObject);
                        i++;
                    }

                    Destroy(other.gameObject); // Détruire l'objet collecté
                    ButtonEO.SetActive(false);
                    
                }
            }
            else
            {
                GetComponent<Renderer>().material.color = scriptableObject.objectColor;
            }
        }
        MachineObjectSo MachineobjectWithSO = other.GetComponent<MachineObjectSo>();
        if (MachineobjectWithSO != null)
        {
            MachineScriptableObject MachinescriptableObject = MachineobjectWithSO.myMachineScriptableObject;
            MenuDisplay menuDisplay = other.GetComponent<MenuDisplay>();
            

            Treatment treatment = other.GetComponent<Treatment>();
            protocoleiNSHALLAH = treatment;

            
            if ( MachinescriptableObject.objectName.Length > 0 )
            {
                RecipeScriptableObject = menuDisplay.RecipeScriptableObject;
                ButtonBuyO.SetActive(true);
                
                if (IsClickedBuy )
                {

                    IsClickedBuy = false;

                    menuDisplay.Clicked();
                    Menu.SetActive(true);
                    
                    //treatment.AddQueue(MachinescriptableObject.SOprefab);
                    //GameObject Combustive = Instantiate(MachinescriptableObject.SOprefab.objectPrefab,other.transform.position + new Vector3(0,0,4f), Quaternion.identity);

                    ButtonBuyO.SetActive(false);
                    
                }
            }

        }

    }

    public void OnClickButtonE()
    {
        if (ButtonE.interactable)
        {
            IsClicked = true;
        }
    }

    public void OnClickButtonBuy()
    {
        if (ButtonBuy.interactable)
        {
            IsClickedBuy = true;
        }
    }

    
    public void OnClickButtonMenu()
    {
        if (ButtonMenu.interactable)
        {
            Menu.SetActive(false);
        }
    }


    public void OnTriggerExit(Collider other)
    {
        ButtonEO.SetActive(false);
        ButtonBuyO.SetActive(false);
    }

    public void OnClick1()
    {
        if (Button1.interactable)
        {
            RecipeSo = RecipeScriptableObject[0];
            if(RecipeScriptableObject.Length>0)
            {
                Debug.Log("Recipe checked");
                int p = 0;
                foreach(var elem in RecipeScriptableObject[0].Input)
                {
                    if(!inventory.items.Contains(elem))
                    {
                        p++;
                    }
                    else
                    {
                        RecipeS0Copy.Add(elem);
                        
                    }

                }
                if(RecipeS0Copy.Count == RecipeScriptableObject[1].Input.Length)
                {
                    foreach(var elem in RecipeS0Copy)
                    {
                        inventory.RemoveItem(elem);
                                                        
                        int j = 0;
                        for(int k = 0;k < imageObjects.Length; k++)
                        {
                            if(imageObjects[k].GetComponent<Image>().sprite.name == elem.objectName)
                            {
                                while (j<5)
                                {
                                    imageObjects[j].GetComponent<Image>().sprite = imageObjects[j+1].GetComponent<Image>().sprite;
                                    j++;
                                }
                                if(j==5)
                                {
                                imageObjects[j].GetComponent<Image>().sprite = null;
                                i--;
                                }
                                break;
                            }
                            j++;
                            
                        }
                    }
                }
                else
                {
                    Debug.Log("Manque de matériaux");
                }               
                if(i==0 && protocoleiNSHALLAH)
                {
                    protocoleiNSHALLAH.AddQueue(RecipeScriptableObject[0]);
                }
            }
    
        }
    }

    public void OnClick2()
    {
        if (Button2.interactable)
        {
            RecipeSo = RecipeScriptableObject[1];
            if(RecipeScriptableObject.Length>0)
            {
                int p = 0;
                foreach(var elem in RecipeScriptableObject[1].Input)
                {
                    if(!inventory.items.Contains(elem))
                    {
                        p++;
                    }
                    else
                    {
                        RecipeS0Copy.Add(elem);
                        
                    }
                }
                if(RecipeS0Copy.Count == RecipeScriptableObject[1].Input.Length)
                {

                
                    foreach(var elem in RecipeS0Copy)
                    {
                        inventory.RemoveItem(elem);
                                                        
                        int j = 0;
                        for(int k = 0;k < imageObjects.Length; k++)
                        {
                            if(imageObjects[k].GetComponent<Image>().sprite.name == elem.objectName)
                            {
                                while (j<5)
                                {
                                    imageObjects[j].GetComponent<Image>().sprite = imageObjects[j+1].GetComponent<Image>().sprite;
                                    j++;
                                }
                                if(j==5)
                                {
                                imageObjects[j].GetComponent<Image>().sprite = null;
                                i--;
                                }
                                break;
                            }
                            j++;
                            
                        }
                    
                    }
                }
                else
                {
                    Debug.Log("Manque de matériaux");
                }
                if(i==0 && protocoleiNSHALLAH)
                {
                    protocoleiNSHALLAH.AddQueue(RecipeScriptableObject[0]);
                }
            }
        }
    }

    public void OnClick3()
    {
        if (Button3.interactable)
        {
            RecipeSo = RecipeScriptableObject[2];
            if(RecipeScriptableObject.Length>0)
            {
                int p = 0;
                foreach(var elem in RecipeScriptableObject[2].Input)
                {   
                    if(!inventory.items.Contains(elem))
                    {
                        p++;
                    }
                    else
                    {
                        RecipeS0Copy.Add(elem);
                        
                    }
                }
                if(RecipeS0Copy.Count == RecipeScriptableObject[1].Input.Length)
                {
                    foreach(var elem in RecipeS0Copy)
                    {


                        inventory.RemoveItem(elem);
                                                        
                        int j = 0;
                        for(int k = 0;k < imageObjects.Length; k++)
                        {
                            if(imageObjects[k].GetComponent<Image>().sprite.name == elem.objectName)
                            {
                                while (j<5)
                                {
                                    imageObjects[j].GetComponent<Image>().sprite = imageObjects[j+1].GetComponent<Image>().sprite;
                                    j++;
                                }
                                if(j==5)
                                {
                                imageObjects[j].GetComponent<Image>().sprite = null;
                                i--;
                                }
                                break;
                            }
                            j++;
                            
                        }
                    
                
                    }
                
                }
                else
                {
                    Debug.Log("Manque de matériaux");
                }
                if(i==0 && protocoleiNSHALLAH)
                {
                    protocoleiNSHALLAH.AddQueue(RecipeScriptableObject[0]);
                }
            }
        }
    }
}   

