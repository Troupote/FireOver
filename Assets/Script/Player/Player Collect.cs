using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


public class PlayerCollect : MonoBehaviour
{
    public GameObject[] imageObjects;
    
    public Button ButtonE;
    public GameObject ButtonEO;
    public Button buttonTrash;

    public Button ButtonBuy;
    public GameObject ButtonBuyO;
    private bool IsClicked = false;
    private bool IsClickedBuy = false;

    public GameObject Menu;
    public Button ButtonMenu;
    public Text ButtonMenuText;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    [SerializeField] private Treatment protocoleiNSHALLAH;


    private int i = 0;
    public Inventory inventory;

    private RecipesSO[] RecipeScriptableObject;
    private List<RecipesSO> RecipeS0Copy = new List<RecipesSO> (); 

    private RecipesSO RecipeSo;
    public PlayerMovement playerMovement;

    void Start()
    {
        ButtonEO.SetActive(false);
        ButtonBuyO.SetActive(false);
        Menu.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        AttachingObject objectWithSO = other.GetComponent<AttachingObject>();
        if (objectWithSO != null)
        {
            RecipesSO scriptableObject = objectWithSO.myScriptableObject;
            
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
            ButtonMenuText.text = "Melt "+other.name;

            
            if ( MachinescriptableObject.objectName.Length > 0 )
            {
                RecipeScriptableObject = menuDisplay.RecipeScriptableObject;
                ButtonBuyO.SetActive(true);
                
                if (IsClickedBuy )
                {

                    IsClickedBuy = false;

                    menuDisplay.Clicked();
                    Menu.SetActive(true);
                    playerMovement.vitesseDeplacement = 0f; 
                    

                    
                    
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
            GameObject selectionPanel = GameObject.Find("Canvas");
            Transform CraftingMenu = selectionPanel.transform.Find("CraftingMenu");
            Transform CraftingMenuPanel = CraftingMenu.transform.Find("Crafting Menu Panel");
            Transform view = CraftingMenuPanel.transform.Find("View");
            Transform content = view.transform.Find("Content");
            foreach (Transform child in content)
            {
                // Si le nom de l'enfant contient "Panel", détruit l'objet
                if (child.name.Contains("Panel"))
                {
                    Destroy(child.gameObject);
                }
            }
            playerMovement.vitesseDeplacement = 1.5f; 


        }
    }


    public void OnTriggerExit(Collider other)
    {
        ButtonEO.SetActive(false);
        ButtonBuyO.SetActive(false);
    }


    public void OnClickRubbish()
    {
        if(buttonTrash.interactable)
        {

            inventory.RemoveItem(inventory.items[inventory.items.Count-1]);
            imageObjects[inventory.items.Count].GetComponent<Image>().sprite = null;
            i--;

                                            
            // int j = 0;
            // for(int k = 0;k < imageObjects.Length; k++)
            // {
            //     RecipesSO baseItem = inventory.items[inventory.items.Count-1];


            //     if(imageObjects[k].GetComponent<Image>().sprite.name == baseItem.objectName)
            //     {
            //         while (j<5 )
            //         {
            //             imageObjects[j].GetComponent<Image>().sprite = imageObjects[j+1].GetComponent<Image>().sprite;
            //             j++;
                        
            //         }
            //         if(j==5)
            //         {
            //             imageObjects[j].GetComponent<Image>().sprite = null;
            //             i--;
            //         }
            //         // if(inventory.items.Count==1)
            //         // {
            //         //     imageObjects[j].GetComponent<Image>().sprite = null;
            //         //     i--;
            //         // }

            //         break;
            //     }
            //     j++;
                
            // }
        }
    }

    public void OnClick1()
    {
        if (Button1.interactable)
        {
            SelectAnDelete(0);
        }
    }

    public void OnClick2()
    {
        if (Button2.interactable)
        {
            SelectAnDelete(1);
        }
    }

    public void OnClick3()
    {
        // Vérifie si le bouton est interactif
        if (Button3.interactable)
        {
            SelectAnDelete(2);
        }
    }

    void SelectAnDelete(int whichone)
    {
                  // Récupère le troisième élément du tableau de recettes
        RecipeSo = RecipeScriptableObject[whichone];
        // Copie les objets de l'inventaire
        
        List<RecipesSO> InventoryCopy = new List<RecipesSO>(inventory.items);

        if (RecipeScriptableObject.Length > 0)
        {
            Debug.Log(" Les objets de la recette sont :");
            // Parcourt les éléments de la recette
            foreach (var elem in RecipeSo.Input)
            {
                // Vérifie si l'élément est dans l'inventaire
                if (InventoryCopy.Contains(elem))
                {
                    RecipeS0Copy.Add(elem);
                    InventoryCopy.Remove(elem);
                }
                Debug.Log(elem.objectName + " ");
            }


            Debug.Log(" Les objets de l'inventaire sont :");
            // Affiche les objets dans l'inventaire
            foreach (var item in inventory.items)
            {
                Debug.Log(item.objectName + " ");
            }

            Debug.Log(" Les objets de la liste copiée sont :");
            // Affiche les objets de la liste copiée
            foreach (var item in RecipeS0Copy)
            {
                Debug.Log(item.objectName + " ");
            }

            // Vérifie si tous les objets nécessaires sont dans la liste copiée
            if (RecipeS0Copy.Count == RecipeSo.Input.Length)
            {
                Debug.Log("tous les objets nécessaires sont dans la liste copiée");

                if (protocoleiNSHALLAH)
                {
                    protocoleiNSHALLAH.AddQueue(RecipeScriptableObject[whichone]);
                    Debug.Log("Done");
                }
                foreach (var elem in RecipeS0Copy)
                {
                    // Supprime l'élément de l'inventaire
                    inventory.RemoveItem(elem);

                    Debug.Log("Supprimé");

                    for (int k = 0; k < imageObjects.Length; k++)
                    {
                        int j = k;
                        if (imageObjects[k].GetComponent<Image>().sprite.name == elem.objectName)
                        {
                            
                            while (j < 5)
                            {
                                imageObjects[j].GetComponent<Image>().sprite = imageObjects[j + 1].GetComponent<Image>().sprite;
                                j++;
                                Debug.Log("trouvé j="+ j.ToString()+" k : " + k.ToString());
                            }
                            Debug.Log(imageObjects[5].name + " object name :"+elem.objectName);
                            if (j == 5)
                            {
                                imageObjects[j].GetComponent<Image>().sprite = null;
                                i--;
                            }
                            break;
                            
                        }
                        
                    }
                }

                
            }
            else
            {
                UnityEngine.Debug.Log("Manque de matériaux");
            }
            // Ajoute à la queue si certaines conditions sont remplies
 

            RecipeS0Copy.Clear();
        }
    }
    

}   

