using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCamComputer : MonoBehaviour
{
    public Camera mainCam;
    public Camera computerCam;

    public bool computerOn;
    private bool computerisbeingUse;
    void Start()
    {
        computerCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (AnnaManager.exitAnna)
        {
            ExitComputer();
            AnnaManager.exitAnna = false;
        }
    }
    private void OnMouseDown()
    {
        mainCam.enabled = false;
        mainCam.gameObject.SetActive(false);
        computerCam.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        computerOn = true;

        AnnaManager.startIdentication = computerOn;

    }
    private void ExitComputer() 
    {
        mainCam.enabled = true;
        mainCam.gameObject.SetActive(true);
        computerCam.gameObject.SetActive(false);


        computerOn = false;
        AnnaManager.startIdentication = computerOn;
    }
}
