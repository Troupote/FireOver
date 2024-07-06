using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public GameObject[] imageObjects;
    private int i = 0;
    public Button ButtonE;
    public GameObject ButtonEO;
    private bool IsClikked = false;

    void Start()
    {
        ButtonEO.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {

        ObjectWithSO objectWithSO = other.GetComponent<ObjectWithSO>();
        if (objectWithSO != null)
        {
            MyScriptableObject scriptableObject = objectWithSO.myScriptableObject;
            if (scriptableObject.objectName == "feur")
            {
                ButtonEO.SetActive(true);
                if(IsClikked)
                {
                    IsClikked = false;
                    
                    if (i < imageObjects.Length)
                    {
                        imageObjects[i].GetComponent<Image>().sprite = scriptableObject.ObjectImage;
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
    }
    public void OnClickButtonE()
    {
        if(ButtonE.IsInteractable())
        {
            IsClikked = true;
        }

        
    }

    public void OnTriggerExit(Collider other)
    {
        ButtonEO.SetActive(false); 
    }

}
