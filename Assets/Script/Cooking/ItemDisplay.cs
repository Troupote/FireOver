using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public MyScriptableObject myScriptableObject;

    void Start()
    {
        if (myScriptableObject != null)
        {
            Debug.Log("Name: " + myScriptableObject.objectName);
            Debug.Log("Value: " + myScriptableObject.objectValue);
            GetComponent<Renderer>().material.color = myScriptableObject.objectColor;
        }
        else
        {
            Debug.LogWarning("MyScriptableObject is not assigned!");
        }
    }
}
