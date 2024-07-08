using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Treatment : MonoBehaviour 
{
    private List<BaseScriptableObject> Queue = new List<BaseScriptableObject>();
    private IEnumerator enumerator;


    public void Start()
    {
        enumerator = Treat();
    }

    public void AddQueue(RecipesSO Item)
    {
        foreach(BaseScriptableObject elem in Item.Input)
        {
            AddQueueObject(elem);
            
            
        }
    }

    public void AddQueueObject(BaseScriptableObject Item)
    {
        if (Queue.Count == 0)
        {
            Queue.Add(Item);
            
            
            StartCoroutine(Treat());
            Debug.Log("Temp created");
 
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
            BaseScriptableObject Temp = Queue[0];

            GameObject ObjectToSpawn = Instantiate(Temp.objectPrefab,transform.position + new Vector3(0, 0, 4f), Quaternion.identity);
            

            yield return new WaitForSeconds(2);

            Destroy(ObjectToSpawn);
            Queue.RemoveAt(0);
            

            yield return new WaitForSeconds(2);

        }
    }
}
