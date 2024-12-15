using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWhiteShader : MonoBehaviour
{

    [Header("Référence de l'objet cible")]
    public Transform targetObject; // L'objet dont la position sera suivie

    [Header("Décalage par rapport à l'objet cible")]
    public Vector3 offset; // Décalage par rapport à l'objet cible

    void Update()
    {
        if (targetObject != null)
        {
            // Calculer la nouvelle position en tenant compte de la rotation de l'objet cible
            Vector3 rotatedOffset = targetObject.rotation * offset;
            transform.position = targetObject.position + rotatedOffset;
        }
    }
}

