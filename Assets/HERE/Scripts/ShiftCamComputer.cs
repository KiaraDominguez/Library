using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCamComputer : MonoBehaviour
{
    public Camera mainCam;
    public Camera computerCam;

    public bool ComputerOn;
    void Start()
    {
        computerCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        mainCam.enabled = false;
        mainCam.gameObject.SetActive(false);
        computerCam.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ComputerOn = true;

        AnnaManager.startIdentication = ComputerOn;
    }
}
