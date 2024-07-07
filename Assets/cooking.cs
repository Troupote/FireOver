using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooking : MonoBehaviour
{
    // Variables pour contr�ler l'effet de tremblement
    public float shakeAmount = 10.0f;
    public bool isShaking = true;
    private Vector3 initialLocalPosition;
    private Transform meshTransform;

    void Start()
    {
        // Trouver le MeshFilter dans l'objet actuel ou ses enfants
        MeshFilter meshFilter = GetComponentInChildren<MeshFilter>();

        if (meshFilter != null)
        {
            // Sauvegarder la position locale initiale du mesh
            meshTransform = meshFilter.transform;
            initialLocalPosition = meshTransform.localPosition;
        }
        else
        {
            Debug.LogWarning("Aucun MeshFilter trouv� sur cet objet ou ses enfants.");
        }
    }

    void Update()
    {
        if (isShaking && meshTransform != null)
        {
            ShakeMesh();
        }
    }

    void ShakeMesh()
    {
        // G�n�rer un petit d�calage al�atoire pour chaque axe
        float offsetX = Random.Range(-shakeAmount, shakeAmount);
        float offsetY = Random.Range(-shakeAmount, shakeAmount);
        float offsetZ = Random.Range(-shakeAmount, shakeAmount);

        // Appliquer le d�calage � la position locale initiale
        meshTransform.localPosition = initialLocalPosition + new Vector3(offsetX, offsetY, offsetZ);
    }

    // M�thode pour activer/d�sactiver le tremblement
    public void ToggleShake(bool shake)
    {
        isShaking = shake;
        if (!shake && meshTransform != null)
        {
            // R�initialiser la position locale � sa position initiale
            meshTransform.localPosition = initialLocalPosition;
        }
    }
}
