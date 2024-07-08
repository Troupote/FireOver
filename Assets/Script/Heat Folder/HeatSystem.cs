using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class HeatSystem : MonoBehaviour
{

    public float WorldHeatValue = 15;
    public Text HeatText;
    public float PlayerHeatValue = 0;
    public MeshRenderer SnowMesh;
    private Material SnowMaterial;

    void Start()
    {
        SnowMaterial = SnowMesh.material;
        SnowMaterial.SetFloat("_HSnow", 0.0004f);
        StartCoroutine(Heater());
    }

    public void AddPermanentHeatValue(float v)
    {
        WorldHeatValue += v;
    }

    public void RemouvePermanentHeatValue(float v)
    {
        WorldHeatValue -= v;
    }

    public void AddPlayerHeat(float v)
    {
        PlayerHeatValue += v;
    }

    public void RemouvePlayerHeat(float v)
    {
        PlayerHeatValue -= v;
    }

    // Définir la coroutine
    IEnumerator Heater()
    {
        while (true)
        {
            float tmp = PlayerHeatValue + WorldHeatValue;
            float lerp = -0.000005f * WorldHeatValue + 0.0f * (1 - WorldHeatValue);

            SnowMaterial.SetFloat("_HSnow", Mathf.Clamp(lerp, 0.00002f, 0.001f));

            SnowMaterial.SetFloat("_HSnowRatio", ((lerp - 0.00002f) / (0.001f - 0.00002f) * 0.001f));

            Debug.Log("Ammo left: " + ((lerp - 0.00002f) / (0.001f - 0.00002f) * 0.001f), this);
            HeatText.text = tmp.ToString("F2") + " °C";
            WorldHeatValue -= 1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
