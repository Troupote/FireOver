using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<BaseScriptableObject> items = new();
    public Button buttonTrash;

    public void AddItem(BaseScriptableObject itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(BaseScriptableObject itemToRemove)
    {
        items.Remove(itemToRemove);
    }




}