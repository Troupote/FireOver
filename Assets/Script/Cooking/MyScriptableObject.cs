using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_Stone : ScriptableObject
{
    [Tooltip("Stackable")]
    public bool Stackable = false;

    [Tooltip("Name")]
    public string ObjectName = "defaultName";

    [Tooltip("Image")]
    public Texture2D Thumbnail ; 

    [Tooltip("Thumbnail")]
    public Sprite ObjectImage ; 

}

