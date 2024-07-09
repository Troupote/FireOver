using UnityEngine;
using UnityEngine.UI;


public abstract class RecipesSO : ScriptableObject
{
    public string objectName;

    public RecipesSO[] Input;
    public GameObject objectPrefab;
    public  Sprite ObjectImage;
    public bool IsRecipe;
    public Color objectColor;

}
