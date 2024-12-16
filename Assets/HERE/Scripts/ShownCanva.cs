using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShownCanva : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private bool canvaOpen;

    void Start()
    {
        UpdateCanvasState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Vérifie le clic gauche
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit: " + hit.transform.name);
                if (hit.transform == transform)
                {
                    Debug.Log("Objet cliqué, ouverture du canvas");
                    canvaOpen = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && canvaOpen)
        {
            canvaOpen = false;
        }
        UpdateCanvasState();

    }
    void UpdateCanvasState()
    {
        if (canvaOpen)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

}
