using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCamComputer : MonoBehaviour
{
    public Camera mainCam;
    public Camera computerCam;
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
    }
}
