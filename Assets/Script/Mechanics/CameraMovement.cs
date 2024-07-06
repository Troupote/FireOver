using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // R�f�rence au joueur
    public Vector3 offset = new Vector3(0, 5, -5); // Offset de la cam�ra

    void LateUpdate()
    {
        // Met � jour la position de la cam�ra en fonction de la position du joueur et de l'offset
        transform.position = player.position + offset;
    }
}
