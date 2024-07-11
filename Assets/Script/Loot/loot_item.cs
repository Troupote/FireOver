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
        for (int i = 0; i<50 ;i++)
        {
            if(lootPrefab[i%(lootPrefab.Length)].name == "WoodPrefab")
            {
                Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-50,50),0,UnityEngine.Random.Range(-50,50));
                GameObject newLoots = Instantiate(lootPrefab[i % lootPrefab.Length], randomPosition, Quaternion.Euler(-90, 0, 0));
            }
            else
            {   
                Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-50,50),3,UnityEngine.Random.Range(-50,50));
                GameObject newLoots = Instantiate(lootPrefab[i%(lootPrefab.Length)], randomPosition, Quaternion.identity);
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
