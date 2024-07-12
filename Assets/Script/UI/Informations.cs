using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Informations : MonoBehaviour
{
    public GameObject Canvas; 
    public Text infText; 
    public Image background; 

    private Color originalColor; 
    private Color originalColor2; 
    private float originalAlpha;

    void Start()
    {
        Canvas.SetActive(false); 
        originalColor = background.color;
        originalColor2 = infText.color; 
        originalAlpha = originalColor2.a; 
    }

    public IEnumerator ChangeCanvasColorOverTime(Color startColor, Color targetColor, float duration, Color targetColor2)
    {
        background.color = startColor; 

        Canvas.SetActive(true); 

        float timer = 0f;
        while (timer < duration)
        {
            timer += UnityEngine.Time.deltaTime;
            float progress = timer / duration;
            background.color = Color.Lerp(startColor, targetColor, progress);

            Color newColor = new Color(originalColor2.r, originalColor2.g, originalColor2.b, Mathf.Lerp(originalAlpha, 1f, progress));
            infText.color = newColor;

            yield return null;
        }

        infText.color = targetColor2;

        background.color = targetColor;

        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator ReverseCanvasColorOverTime(float duration,Color original)
    {
        yield return StartCoroutine(ChangeCanvasColorOverTime(background.color, originalColor, duration , original));

        Canvas.SetActive(false); 


        infText.text = ""; 
    }

    public IEnumerator ChangeSliderValueOverTime(string request)
    {
        Color targetColor = Color.red; 
        Color targetColor2  = Color.black;
        float duration = 0.5f; 

        yield return StartCoroutine(ChangeCanvasColorOverTime(originalColor, targetColor, duration,targetColor2));

        infText.text = request; 

        yield return new WaitForSeconds(0.5f); 

        yield return StartCoroutine(ReverseCanvasColorOverTime(duration,originalColor2));
    }
}
