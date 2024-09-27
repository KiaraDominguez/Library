using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    public InputActionAsset actions;
    private InputAction xAxis;
    private InputAction zAxis;

    [SerializeField ] float speed = 1f;

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
        float zMove = zAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * zMove * transform.forward;
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * transform.right;
    }
}
