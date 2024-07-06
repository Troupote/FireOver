using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    // Start is called before the first frame update
    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void OnClickButton1()
    {
        if (button1.IsInteractable())
        {
            canvas1.SetActive(true);
            canvas2.SetActive(false);
            canvas3.SetActive(false);
        }
    }

    public void OnClickButton2()
    {
        if (button2.IsInteractable())
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            canvas3.SetActive(false);  
        }
    }

    public void OnClickButton3()
    {
        if (button3.IsInteractable())
        {
            canvas1.SetActive(false);
            canvas2.SetActive(false);
            canvas3.SetActive(true);
        }
    }
}
