using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentEvolution : MonoBehaviour
{
    public GameObject[] panels;
    
    void OnDisable()
    {

        for (int i = 0; i < panels.Length; i++)
        {
            Text text = panels[i].GetComponentInChildren<Text>();
            text.text = null;
            

            Transform[] childTransforms = panels[i].GetComponentsInChildren<Transform>();

            foreach (Transform child in childTransforms)
            {
                if(child.name.Contains("Image"))
                {
                    Image image = child.GetComponent<Image>();
                    image.sprite = null;
                    
                }
                
                
            }



        }
    }
}
