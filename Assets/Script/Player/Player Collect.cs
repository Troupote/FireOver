using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public GameObject[] imageObjects;
    
    public Button ButtonE;
    public GameObject ButtonEO;

    public Button ButtonBuy;
    public GameObject ButtonBuyO;
    private bool IsClicked = false;
    private bool IsClickedBuy = false;

    private int i = 0;
    public Inventory inventory;

    void Start()
    {
        ButtonEO.SetActive(false);
        ButtonBuyO.SetActive(false);
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
            Treatment treatment = other.GetComponent<Treatment>(); 
            
            if ( MachinescriptableObject.objectName.Length > 0 )
            {
                
                ButtonBuyO.SetActive(true);

                if (IsClickedBuy )
                {
                    if(inventory.items.Contains(MachinescriptableObject.SOprefab))
                    {

                        IsClickedBuy = false;
                        treatment.AddQueue(MachinescriptableObject.SOprefab.objectPrefab);
                        //GameObject Combustive = Instantiate(MachinescriptableObject.SOprefab.objectPrefab,other.transform.position + new Vector3(0,0,4f), Quaternion.identity);
                        
                        if(inventory.items.Contains(MachinescriptableObject.SOprefab))
                        {
                            inventory.RemoveItem(MachinescriptableObject.SOprefab);
                            int j = 0;
                            for(int k = 0;k < imageObjects.Length; k++)
                            {
                                if(imageObjects[k].GetComponent<Image>().sprite.name == MachinescriptableObject.SOprefab.objectName)
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
                            
                            Debug.Log("trouvé");
                        }
                        else
                        {
                            Debug.Log("pas trouvé");
                        }

                        ButtonBuyO.SetActive(false);
                    }
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

    public void OnTriggerExit(Collider other)
    {
        ButtonEO.SetActive(false);
        ButtonBuyO.SetActive(false);
    }
}
