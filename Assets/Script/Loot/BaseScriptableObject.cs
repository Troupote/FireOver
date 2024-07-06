using UnityEngine;
using UnityEngine.UI;


public abstract class BaseScriptableObject : ScriptableObject 
{
    public string objectName;

    public GameObject objectPrefab;
    public int objectValue;
    public Color objectColor;
    public Sprite ObjectImage ; 
}
