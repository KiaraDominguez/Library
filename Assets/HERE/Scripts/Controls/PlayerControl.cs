using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    public InputActionAsset actions;
    private InputAction xAxis;
    private InputAction zAxis;

    [SerializeField ] float speed = 1f;

    // pour faire matcher la direction de la camera avec les mouvement du joueur
    [SerializeField] Transform cam; 

    void Awake()
    {
        xAxis = actions.FindActionMap("PlayerMap").FindAction("XAxis");
        zAxis = actions.FindActionMap("PlayerMap").FindAction("ZAxis");
    }

    void OnEnable()
    {
        actions.FindActionMap("PlayerMap").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("PlayerMap").Disable();
    }

    void Update()
    {
        MoveX();
        MoveZ();
    }

    private void MoveZ()
    {
        // prend la position z de la camera
        Vector3 camForward = cam.forward;
        camForward.y = 0f;

        float zMove = zAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * zMove * camForward;
    }

    private void MoveX()
    {
        // prend la position x de la camera
        Vector3 camRight = cam.right;
        camRight.y = 0f;

        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * camRight;
    }
}
