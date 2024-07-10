using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Treatment : MonoBehaviour 
{
    private List<RecipesSO> Queue = new List<RecipesSO>();
    private IEnumerator enumerator;


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

            GameObject ObjectToSpawn = Instantiate(Temp.objectPrefab,transform.position + new Vector3(0, 3, 4f), Quaternion.identity);
            

            yield return new WaitForSeconds(2);

            Destroy(ObjectToSpawn);
            Queue.RemoveAt(0);
            

            yield return new WaitForSeconds(2);

        }
    }
}
