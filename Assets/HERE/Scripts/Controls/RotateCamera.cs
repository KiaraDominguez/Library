using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float x;
    private float y;
    public float sensitivity = -5f;
    private Vector3 rotate;

    public float rayDistance = 10f;
    public Color rayColor = Color.red;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(x, y * sensitivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;

        Cursor.visible = true;

        // Lancer le Raycast depuis le centre de la caméra
        Ray ray = new Ray(transform.position, transform.forward); // Raycast depuis la caméra

        Debug.DrawRay(transform.position, transform.forward * rayDistance, rayColor);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.Log("Object hit: " + hit.collider.name);
        }
    }
}
