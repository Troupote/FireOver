using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeIngredient : MonoBehaviour
{
    public MachineScriptableObject[] MachineScriptableObject;
    public GameObject[] Panel;
    // Start is called before the first frame update
    void Start()
    {
        for( int i = 0; i<Panel.Length;i++)
        {
            Transform[] childTransforms = Panel[i].GetComponentsInChildren<Transform>();
            List<Image> panelsImages = new List<Image>();
            foreach (Transform child in childTransforms)
            {
                if(child.name.Contains("Image"))
                {
                    Image image = child.GetComponent<Image>();
                    panelsImages.Add(image);
                } 
                
            }

            for (int j = 0; j < MachineScriptableObject[i].SOprefab.Length; j++)
            {
                panelsImages[j].sprite = MachineScriptableObject[i].SOprefab[j].ObjectImage;
                        
            }

            panelsImages.Clear();
        }
        
    }

}
