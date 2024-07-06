using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NewBehaviourScript : MonoBehaviour
{
    public GameObject lootPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i<19 ;i++)
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(0,20),0,UnityEngine.Random.Range(0,20));
            GameObject newLoots = Instantiate(lootPrefab, randomPosition, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
