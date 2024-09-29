using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] new GameObject gameObject;
    [SerializeField] Transform player;

    [SerializeField] float distanceBehind = 5f;
    private Vector3 behindPosition;
    private bool hasAlreadyAppear;

    void Start()
    {
        // Calculer la position derrière le joueur
        behindPosition = player.position - player.forward * distanceBehind;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        //verifie si le joueur rentre dans le trigger et si il n y est pas encore rentrer
        if (other.CompareTag("Player") && (!hasAlreadyAppear))
        {
            // Fait apparaître l'objet derriere le joueur
            gameObject.transform.position = behindPosition;
            gameObject.transform.rotation = player.rotation;
            gameObject.SetActive(true);

            hasAlreadyAppear = true;
        }
    }

    private void PlayerSawIt()
    {
        // prend la position du ghost par rapport au monde et la camera
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);

        bool isInView = viewportPos.x >= 0 && viewportPos.x <= 1 && viewportPos.y >= 0 && viewportPos.y <= 1 && viewportPos.z > 0;

        if (isInView)
        {
            Invoke("HideObject", 1f);
        }
    }

    void Update()
    {
        PlayerSawIt();
    }

    void HideObject()
    {
        // Désactiver le Renderer (rendre l'objet invisible)
       gameObject.GetComponent<Renderer>().enabled = false;
    }

}
