using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Treatment : MonoBehaviour 
{
    private List<GameObject> Queue = new List<GameObject>();
    private IEnumerator enumerator;


    public void Start()
    {
        enumerator = Treat();
    }

    public void AddQueue(GameObject Item)
    {
        Queue.Add(Item);
    }

    public IEnumerator Treat()
    {
        if (Queue.Count > 0)
        {
            GameObject Temp = Queue[0];

            Queue.RemoveAt(0);

            yield return new WaitForSeconds(2);

            GameObject ObjectToSpawn = Instantiate(Temp,transform.position + new Vector3(0, 0, 4f), Quaternion.identity);

        }
    }
}
