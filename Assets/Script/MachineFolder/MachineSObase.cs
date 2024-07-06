using UnityEngine;
using UnityEngine.UI;


public abstract class MachineScriptableObject : ScriptableObject 
{
    public string objectName;

    public BaseScriptableObject SOprefab;
    public GameObject objectPrefab;
    public int objectValue;
    public Color objectColor;
    public Sprite ObjectImage ; 
}
