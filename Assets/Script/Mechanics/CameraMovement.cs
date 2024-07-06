using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public Vector3 offset = new Vector3(0, 5, -5); // Offset de la caméra

    void LateUpdate()
    {
        // Met à jour la position de la caméra en fonction de la position du joueur et de l'offset
        transform.position = player.position + offset;
    }
}
