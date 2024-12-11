using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    // Distance maximale du raycast
    public float maxDistance = 100f;

    // Couche à considérer pour le raycast
    public LayerMask raycastLayerMask;

    void Update()
    {
        // Lancer le raycast au centre de la caméra
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, raycastLayerMask))
        {
            // Si un objet est touché, afficher son nom
            Debug.Log($"Objet regardé : {hit.collider.gameObject.name}");

            // Exemple : Ajouter des interactions spécifiques avec l'objet
            // hit.collider.GetComponent<YourComponent>()?.DoSomething();
        }
    }

    // Affiche une ligne de débogage dans la scène pour visualiser le raycast
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * maxDistance);
    }
}
