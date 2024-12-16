using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float pickupRange = 5f; // Distance maximale pour ramasser un objet
    public LayerMask interactableLayer; // Couches des objets ramassables
    public string firstBook = "firstBook";
    public string secondBook = "secondBook";
    public string thirdBook = "secondBook";


    private Camera playerCamera;

    public static int playerSawBook;

    void Start()
    {
        playerCamera = GetComponent<Camera>();
    }

    void Update()
    {
        CheckForBook();

        if (Input.GetKeyDown(KeyCode.Space)) //&& Manager.playerSeeFirstBook)
        {
            Debug.Log("espace");

            TryPickupObject();
        }
        // Affiche le Raycast pour le debug
        ShowRaycast();
    }

    void CheckForBook()
    {
        // Crée un raycast à partir du centre de l'écran
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // Vérifie si le joueur regarde le livre
        if (Physics.Raycast(ray, out hit, pickupRange, interactableLayer))
        {
            if (hit.collider.gameObject.name == firstBook)
            {
                Manager.playerSeeFirstBook = true;
                playerSawBook = 1;
                //Debug.Log("Le joueur voit le premier livre.");
            }
        }
    }
    void TryPickupObject()
    {
        // Crée un raycast à partir du centre de l'écran
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // Vérifie s'il y a un objet dans la portée
        if (Physics.Raycast(ray, out hit, pickupRange, interactableLayer))
        {
            GameObject pickedObject = hit.collider.gameObject;

            // Vérifie si c'est le premier livre
            if (pickedObject.name == firstBook )
            {
                pickedObject.SetActive(false);
                Manager.playerSeeFirstBook = false;
            }
            else if (pickedObject.name == secondBook)
            {
                
                pickedObject.SetActive(false);
            }
            else if (pickedObject.name == thirdBook)
            {
                
                pickedObject.SetActive(false);
            }
        }

    }

    void ShowRaycast()
    {
        // Crée un raycast à partir du centre de l'écran
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // Dessine le raycast dans la scène
        Debug.DrawRay(ray.origin, ray.direction * pickupRange, Color.red);
    }
}


