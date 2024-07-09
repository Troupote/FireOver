using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<RecipesSO> items = new List<RecipesSO>();


    public void AddItem(RecipesSO itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void RemoveItem(RecipesSO itemToRemove)
    {
        items.Remove(itemToRemove);
    }

}