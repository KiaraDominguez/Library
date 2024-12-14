using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScare : MonoBehaviour
{

    public Transform player;
    public float activationDistance = 5f;

    public GameObject face;
    public GameObject body;

    private Color faceOriginalColor;
    private Color bodyOriginalColor;

    private SkinnedMeshRenderer faceSkinnedMeshRenderer;
    private SkinnedMeshRenderer bodySkinnedMeshRenderer;


    void Start()
    {
        faceSkinnedMeshRenderer = face.GetComponent<SkinnedMeshRenderer>();
        faceOriginalColor = faceSkinnedMeshRenderer.material.color;

        bodySkinnedMeshRenderer = body.GetComponent<SkinnedMeshRenderer>();
        bodyOriginalColor = bodySkinnedMeshRenderer.material.color;

        SetObjectVisibility(false);        
    }

    void Update()
    {
        // Calculer la distance entre le joueur et l'objet
        float distance = Vector3.Distance(player.position, transform.position);

        // Vérifier si la distance est inférieure ou égale à la distance d'activation
        if (distance <= activationDistance)
        {
            SetObjectVisibility(true);
        }
        else
        {
            SetObjectVisibility(false);
        }
        // mettre coroutine qui setVisible true avec un timer ...s quand le joueur est a la bonne distance avec un bool en condiction => ne peut qu'arriver 1 seule fois
    }

    private void SetObjectVisibility(bool isVisible)
    {
        if (isVisible)
        {
            faceSkinnedMeshRenderer.material.color = faceOriginalColor;
            bodySkinnedMeshRenderer.material.color = bodyOriginalColor;
        }
        else
        {
           faceSkinnedMeshRenderer.material.color = new Color(faceOriginalColor.r, faceOriginalColor.g, faceOriginalColor.b, 0f); // Rendre transparent
           bodySkinnedMeshRenderer.material.color = new Color(bodyOriginalColor.r, bodyOriginalColor.g, bodyOriginalColor.b, 0f); // Rendre transparent
        }
    }
}
