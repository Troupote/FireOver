using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooking : MonoBehaviour
{
    // Variables pour contr�ler l'effet de tremblement
    public float shakeAmount = 0.02f;
    public bool isShaking = true;

    private List<Transform> meshTransforms = new List<Transform>();
    private List<Vector3> initialLocalPositions = new List<Vector3>();

    void Start()
    {
        // Trouver tous les MeshFilters dans l'objet actuel ou ses enfants
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        foreach (MeshFilter meshFilter in meshFilters)
        {
            // Sauvegarder la position locale initiale de chaque mesh
            meshTransforms.Add(meshFilter.transform);
            initialLocalPositions.Add(meshFilter.transform.localPosition);
        }

        if (meshFilters.Length == 0)
        {
            Debug.LogWarning("Aucun MeshFilter trouv� sur cet objet ou ses enfants.");
        }
    }

    void Update()
    {
        if (isShaking)
        {
            ShakeMeshes();
        }
    }

    void ShakeMeshes()
    {
        for (int i = 0; i < meshTransforms.Count; i++)
        {
            // G�n�rer un petit d�calage al�atoire pour chaque axe
            float offsetX = Random.Range(-shakeAmount, shakeAmount) / 10.0f;
            float offsetY = Random.Range(-shakeAmount, shakeAmount) / 10.0f;
            float offsetZ = Random.Range(-shakeAmount, shakeAmount) / 10.0f;

            // Appliquer le d�calage � la position locale initiale
            meshTransforms[i].localPosition = initialLocalPositions[i] + new Vector3(offsetX, offsetY, offsetZ);
        }
    }

    // M�thode pour activer/d�sactiver le tremblement
    public void ToggleShake(bool shake)
    {
        isShaking = shake;

        if (!shake)
        {
            ResetMeshPositions();
        }
    }

    // R�initialiser les positions locales � leurs positions initiales
    void ResetMeshPositions()
    {
        for (int i = 0; i < meshTransforms.Count; i++)
        {
            meshTransforms[i].localPosition = initialLocalPositions[i];
        }
    }
}
