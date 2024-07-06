using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<BaseScriptableObject> items = new();

    public void AddItem(BaseScriptableObject itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(BaseScriptableObject itemToRemove)
    {
        items.Remove(itemToRemove);
    }


}