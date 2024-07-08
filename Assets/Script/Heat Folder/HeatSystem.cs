using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatSystem : MonoBehaviour
{

    public float WorldHeatValue = 15;
    public Text HeatText;
    public float PlayerHeatValue = 0;

    void Start()
    {
        StartCoroutine(Heater());
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
            Debug.Log("Ammo left: " + tmp, this);
            HeatText.text = tmp.ToString("F2") + " °C";
            WorldHeatValue -= 0.1f;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
