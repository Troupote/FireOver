using UnityEngine;
using UnityEngine.UI;


public abstract class RecipesSO : ScriptableObject
{
    public string recipeName;

    public BaseScriptableObject[] Input;
    public GameObject PrefabOutput;

}
