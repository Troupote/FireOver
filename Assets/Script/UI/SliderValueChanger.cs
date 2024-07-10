using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderValueChanger : MonoBehaviour
{
    public GameObject Canvas;
    public Slider slider; // Référence au Slider
   
    public float targetValue = 1f; // La valeur cible du slider
    
    // void Start()
    // {
    //     // Commence la coroutine pour changer la valeur du slider
    //     StartCoroutine(ChangeSliderValueOverTime(slider, targetValue, duration));
    // }

    void Start()
    {
        Canvas.SetActive(false);
    }

    IEnumerator ChangeSliderValueOverTime(Slider slider, float targetValue, float duration)
    {
        float startValue = slider.value; // Valeur initiale du slider
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += UnityEngine.Time.deltaTime;
            slider.value = Mathf.Lerp(startValue, targetValue, elapsedTime / duration);
            yield return null; // Attend le prochain frame
        }

        // Assure que la valeur finale est exactement celle désirée
        slider.value = targetValue;
    }

    public void StartSlider(float duration)
    {
        Canvas.SetActive(true);
        StartCoroutine(ChangeSliderValueOverTime(slider, targetValue, duration));
        
    }
    public void EndV()
    {
        Canvas.SetActive(false);
        slider.value = 0f;

    }
}