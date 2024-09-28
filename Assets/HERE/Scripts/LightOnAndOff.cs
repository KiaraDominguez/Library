using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnAndOff : MonoBehaviour
{
    [SerializeField] Light lux;

    public GameObject fuse_Off;

    public GameObject fuse_On;

    public bool lightON;

    void Update()
    {
        if (!lightON)
        {
            fuse_Off.SetActive(false);
            fuse_On.SetActive(true);
            lux.enabled = true;

        }
        else
        {
            fuse_Off.SetActive(true);
            fuse_On.SetActive(false);
            lux.enabled = false;
        }
    }
    private void OnMouseDown()
    {
        lightON = !(lightON);
    }
}
