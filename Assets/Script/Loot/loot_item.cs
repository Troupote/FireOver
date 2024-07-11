using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class loot_item : MonoBehaviour
{
    public GameObject[] lootPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Creation();

    }

    public void Creation()
    {
        for (int i = 0; i<30 ;i++)
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-10,10),2,UnityEngine.Random.Range(-10,10));
            GameObject newLoots = Instantiate(lootPrefab[i%(lootPrefab.Length)], randomPosition, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
