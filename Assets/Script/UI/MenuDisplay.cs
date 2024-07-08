using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDisplay : MonoBehaviour
{
    public RecipesSO[] RecipeScriptableObject;
    public GameObject[] panels;
    private List<GameObject> instantiatedPanels = new List<GameObject>();
    public Treatment treatment;


    public Inventory inventory;

    public MachineObjectSo MachineobjectWithSO ;


    public void Clicked()
    {
        GameObject selectionPanel = GameObject.Find("Canvas");
        Transform CraftingMenu = selectionPanel.transform.Find("CraftingMenu");
        Transform CraftingMenuPanel = CraftingMenu.transform.Find("Crafting Menu Panel");
        Transform view = CraftingMenuPanel.transform.Find("View");
        Transform content = view.transform.Find("Content");

        if (content == null)
        {
            Debug.LogError("GameObject 'content' not found.");
            return;
        }
        
        // Ensure RecipeScriptableObject and panels arrays have matching lengths
        if (RecipeScriptableObject.Length != panels.Length)
        {
            Debug.LogError("Mismatch between RecipeScriptableObject and panels array lengths.");
            return;
        }

        for (int i = 0; i < panels.Length; i++)
        {
            GameObject panel = Instantiate(panels[i], content.transform);

            Text text = panels[i].GetComponentInChildren<Text>();
            text.text = RecipeScriptableObject[i].recipeName;
            

            Transform[] childTransforms = panels[i].GetComponentsInChildren<Transform>();
            List<Image> panelsImages = new List<Image>();

            foreach (Transform child in childTransforms)
            {
                if(child.name.Contains("Image"))
                {
                    Image image = child.GetComponent<Image>();
                    panelsImages.Add(image);
                }
                
                
            }

            // Ensure there are at least 3 Image components in the panel
            if (panelsImages.Count >= 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j < RecipeScriptableObject[i].Input.Length)
                    {
                        panelsImages[j].sprite = RecipeScriptableObject[i].Input[j].ObjectImage;
                        Debug.Log(panelsImages[j].name+"   "+panelsImages[j].sprite.name + "  "+ RecipeScriptableObject[i].Input[j].ObjectImage.name);
                    }
                    else
                    {
                        Debug.LogError("Not enough inputs in RecipeScriptableObject " + i);
                    }
                }
            }

        }

    }


    
}
