using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class HeatMachine : MonoBehaviour
{
    private HeatSystem PlayerHeat;
    public SphereCollider c;
    public float AddAllTime;
    public float AddOnlyInRange;

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO");
        GameObject player = GameObject.FindWithTag("Player");
        PlayerHeat = player.GetComponent<HeatSystem>();
        
        // cast to player
        PlayerHeat.AddPlayerHeat(AddOnlyInRange);

    }

    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO -- HYVERNO");
        PlayerHeat.RemouvePlayerHeat(AddOnlyInRange);
    }

    private void Start()
    {
        PlayerHeat.AddPermanentHeatValue(AddAllTime);
    }
}
