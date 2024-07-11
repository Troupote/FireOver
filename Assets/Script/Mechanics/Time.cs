using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
    public Text timeText;
    public int timeValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountSeconds());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountSeconds()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            timeValue++;

            int seconds = timeValue%60;
            int minutes = timeValue/60;

            if (minutes<10 && seconds<10){ timeText.text = $"0{minutes} : 0{seconds}";}
            else {if (seconds<10){timeText.text = $"{minutes} : 0{seconds}";}
            else if (minutes<10){ timeText.text = $"0{minutes} : {seconds}";}
            else{timeText.text = $"{minutes} : {seconds}";}}

           
        }
       

        
    }

}
