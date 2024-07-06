using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public GameObject[] imageObjects;
    private int i = 0;
    public Button ButtonE;
    public GameObject ButtonEO;
    private bool IsClicked = false;
    public Inventory inventory;

    void Start()
    {
        ButtonEO.SetActive(false);
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
    }

    public void OnClickButtonE()
    {
        if (ButtonE.interactable)
        {
            IsClicked = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        ButtonEO.SetActive(false);
    }
}
