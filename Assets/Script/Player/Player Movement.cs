using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float vitesseDeplacement = 1.5f;

    void Start()
    {
        transform.position = new Vector3(0,0,0);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Translate(Vector3.right* vitesseDeplacement * UnityEngine.Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(Vector3.left * vitesseDeplacement * UnityEngine.Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(Vector3.back * vitesseDeplacement * UnityEngine.Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.Translate(Vector3.forward * vitesseDeplacement * UnityEngine.Time.deltaTime);
        }

    }
}
