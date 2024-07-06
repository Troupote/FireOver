using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewMyScriptableObject", menuName = "ScriptableObjects/MyScriptableObject", order = 1)]

public class MyScriptableObject : ScriptableObject
{
    public string objectName;
    public int objectValue;
    public Color objectColor;

    public Sprite ObjectImage ; 
}
