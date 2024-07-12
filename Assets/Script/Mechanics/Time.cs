using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
    public Text timeText;
    public int timeValue = 0;
    public GameObject Canvas;
    public GameObject Canvasred;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountSeconds());
        Canvas.SetActive(false);
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
            if(timeValue > 1200 && !Canvasred.activeSelf)
            {
                Canvas.SetActive(true);
                Time.timeScale = 0f;

            }

            int seconds = timeValue%60;
            int minutes = timeValue/60;

            if (minutes<10 && seconds<10){ timeText.text = $"0{minutes} : 0{seconds}";}
            else {if (seconds<10){timeText.text = $"{minutes} : 0{seconds}";}
            else if (minutes<10){ timeText.text = $"0{minutes} : {seconds}";}
            else{timeText.text = $"{minutes} : {seconds}";}}

           
        }
       

        
    }

}
