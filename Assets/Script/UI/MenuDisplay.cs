using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDisplay : MonoBehaviour
{
    public RecipesSO[] RecipeScriptableObject;
    public GameObject Menu;
    public GameObject PanelPrefab;
    private List<GameObject> panels = new List<GameObject>();




    void Start()
    {
        Debug.Log("=================================================================");
        for (int i = 0; i < RecipeScriptableObject.Length; i++)
        {
            GameObject newPanel = Instantiate(PanelPrefab, Menu.transform);
            newPanel.transform.SetParent(Menu.transform, false);
            panels.Add(newPanel);
            Text a = newPanel.GetComponentInChildren<Text>();
            a.text = "feur";
            Debug.Log(Menu.transform);
        }
        Debug.Log("=================================================================");
        /*
         *         Debug.Log("=================================================================");

        foreach (var RS in RecipeScriptableObject)
        {
            GameObject newPanel = Instantiate(PanelPrefab, Menu.transform);
            newPanel.transform.SetParent(Menu.transform, false);
            panels.Add(newPanel);
            Debug.Log(RS.recipeName);
        }
         * 
         * for (int i = 0; i < RecipeScriptableObject.Length; i++)
        {
            GameObject newPanel = Instantiate(PanelPrefab, Menu.transform);
            newPanel.transform.SetParent(Menu.transform, false);
            panels.Add(newPanel);
        }   

        for(int i = 0; i < panels.Count ;i++ )
        {
            Text text = panels[i].GetComponentInChildren<Text>();
            text.text = RecipeScriptableObject[i].recipeName;  
            Button button = panels[i].GetComponentInChildren<Button>();
            Image[] imageComponents = panels[i].GetComponentsInChildren<Image>();
            List<Image> images = new List<Image>(imageComponents);
            int j = 0;
            foreach (var elem in images)
            {
                elem.sprite = RecipeScriptableObject[i].Input[j].ObjectImage;
                j++;
            }
        }*/
    }
}
