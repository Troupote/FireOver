using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Treatment : MonoBehaviour 
{
    private List<RecipesSO> Queue = new List<RecipesSO>();
    private IEnumerator enumerator;
    public SliderValueChanger sliderchange;


    public void Start()
    {
        enumerator = Treat();
    }

    public void AddQueue(RecipesSO Item)
    {
        if (Queue.Count == 0)
        {
            Queue.Add(Item);
            
            Debug.Log("Temp created");
            StartCoroutine(Treat());
            
 
        }
        else
        {
            Queue.Add(Item);
        }
    }



    public IEnumerator Treat()
    {

        while (Queue.Count > 0)
        {
            RecipesSO Temp = Queue[0];

            List<GameObject> spawnedObjects = new List<GameObject>();
            float j = -1f;
            foreach (var elem in Temp.Input)
            {
                GameObject ObjectMatToSpawn = Instantiate(elem.objectPrefab, transform.position + new Vector3(j, 0, 5f), Quaternion.identity);
                spawnedObjects.Add(ObjectMatToSpawn);
                j++;
            }
            j = -1f;

            sliderchange.StartSlider(20);
            Debug.Log("Done");
            yield return new WaitForSeconds(20);
            sliderchange.EndV();

            foreach (var obj in spawnedObjects)
            {
                Destroy(obj);
            }

            GameObject ObjectToSpawn = Instantiate(Temp.objectPrefab, transform.position + new Vector3(0, 0, -5f), Quaternion.identity);
            yield return new WaitForSeconds(2); 
            Queue.RemoveAt(0);
            

            

        }
    }
}
