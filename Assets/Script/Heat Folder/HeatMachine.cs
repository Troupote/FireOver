using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class HeatMachine : MonoBehaviour
{
    public HeatSystem PlayerHeat;
    public BoxCollider c;
    public float AddAllTime;
    public float AddOnlyInRange;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO");

        // cast to player

        PlayerHeat.AddPlayerHeat(AddOnlyInRange);

    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO");
        PlayerHeat.RemouvePlayerHeat(AddOnlyInRange);
    }

    private void Start()
    {
        PlayerHeat.AddPlayerHeat(AddAllTime);
    }
}
