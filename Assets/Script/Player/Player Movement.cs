using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float vitesseDeplacement = 1.5f;


    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move += Vector3.right;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move += Vector3.left;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            move += Vector3.back;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move += Vector3.forward;
        }

        transform.Translate(move * vitesseDeplacement * UnityEngine.Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(transform.position.z, minZ, maxZ);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
