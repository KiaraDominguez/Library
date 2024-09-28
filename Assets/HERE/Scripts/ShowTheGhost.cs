using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTheGhost : MonoBehaviour
{
    [SerializeField] GameObject ghost;


    void Start()
    {   
    }

    void Update()
    {
        // prend la position du ghost par rapport au monde et la camera
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(ghost.transform.position);

        // check si l'object est en dehors de field of view de la camera
        // viewport is between (0, 0) and (1, 1)
        bool isOutOfView = viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || viewportPos.z < 0;

        // Set la visibilité par rapport au bool isOutOfView
        ghost.SetActive(isOutOfView);
    }
}
