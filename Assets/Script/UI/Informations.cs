using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informations : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Canvas;
    public Text InfText;


    void Start()
    {
        Canvas.SetActive(false);
    }


    public IEnumerator  ChangeSliderValueOverTime(string request)
    {

        Canvas.SetActive(true);
        InfText.text = request;

        yield return new WaitForSeconds(2f); 
        Canvas.SetActive(false);

    }


}
