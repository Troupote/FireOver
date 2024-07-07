using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public float HeatValue;
    public Text HeatText;

    void Start()
    {
        HeatValue = 15.0f;
        StartCoroutine(Heater());
    }


    // Définir la coroutine
    IEnumerator Heater()
    {
        HeatText.text = HeatValue.ToString() + " °C";
        HeatValue += 0.1f;
        yield return new WaitForSeconds(1f);

    }
}
