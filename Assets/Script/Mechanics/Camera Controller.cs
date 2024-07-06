using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public Vector3 ajust;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + ajust;
    }
}
