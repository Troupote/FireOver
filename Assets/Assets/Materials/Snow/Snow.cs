using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Snow : MonoBehaviour
{
    public RenderTexture renderTexture;
    public Renderer renderer;
    Texture2D texture;

    private void Start()
    {
        texture = new Texture2D (renderTexture.width, renderTexture.height);
        renderer.material.mainTexture = texture;
    }
    int step = 0;

    private void Update()
    {
        step++;

        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        for (int i = 0; i < renderTexture.width * .2f; i++)
            for (int j = 0; j < renderTexture.height; j++)
            {
                
                texture.SetPixel((step + i), j, new Color(1, 0, 0));
            }
        texture.Apply();
        RenderTexture.active = null;
    }
}
