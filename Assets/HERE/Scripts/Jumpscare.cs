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
            Debug.Log("oK");
            // Calculer la position derrière le joueur
            Vector3 spawnPosition = player.position - player.forward * distanceBehind;
            spawnPosition.y += verticalOffset;

            // Instancier l'objet
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Player ou objectToSpawn n'est pas assigné.");
        }
    }
}