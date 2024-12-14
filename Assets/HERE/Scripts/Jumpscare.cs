using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public Transform player;
    public GameObject objectToSpawn;
    public float distanceBehind = 2f;
    public float verticalOffset = 0f;

    void OnEnable()
    {
        Manager.jumpscare += SpawnObject;
    }

    void OnDisable()
    {
        Manager.jumpscare -= SpawnObject;
    }
    public void SpawnObject()
    {
        if (player != null && objectToSpawn != null)
        {
            // Calculer la position derrière le joueur, opposé à la direction du regard
            Vector3 spawnPosition = player.position - player.forward * distanceBehind;
            spawnPosition.y += verticalOffset;

            // Orienter l'objet pour qu'il fasse face à la même direction que le joueur
            Quaternion spawnRotation = Quaternion.LookRotation(-player.forward, Vector3.up);

            // Déplacer et orienter l'objet
            objectToSpawn.transform.position = spawnPosition;
            objectToSpawn.transform.rotation = spawnRotation;

            // Lancer la coroutine pour vérifier si le joueur regarde et désactiver l'objet
            StartCoroutine(DestroyAfterPlayerViews(objectToSpawn));
        }
        else
        {
            Debug.LogWarning("Player ou objectToSpawn n'est pas assigné.");
        }
    }

    // Coroutine pour désactiver l'objet après que le joueur l'ait vu
    private System.Collections.IEnumerator DestroyAfterPlayerViews(GameObject spawnedObject)
    {
        bool hasBeenSeen = false;
        float timer = 0f;

        while (timer < 2f)
        {
            Vector3 toObject = (spawnedObject.transform.position - player.position).normalized;
            float dotProduct = Vector3.Dot(player.forward, toObject);

            // Vérifie si l'objet est dans le champ de vision du joueur (angle avant)
            if (dotProduct > 0.5f) // Ajustez le seuil si nécessaire
            {
                hasBeenSeen = true;
            }

            if (hasBeenSeen)
            {
                timer += Time.deltaTime;
            }

            yield return null;
        }

        spawnedObject.SetActive(false);
    }
}