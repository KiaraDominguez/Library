using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnAndOff : MonoBehaviour
{
    [SerializeField] Light lux;
    [SerializeField] Light redLightFuses;

    [SerializeField] GameObject obj_1;
    [SerializeField] GameObject obj_2;
    [SerializeField] GameObject obj_3;
    [SerializeField] GameObject obj_4;
    [SerializeField] GameObject obj_5;
    [SerializeField] GameObject obj_6;
    [SerializeField] GameObject obj_7;

    public GameObject fuse_Off;
    public GameObject fuse_On;

    public bool lightON;

    void Start()
    {
        redLightFuses.enabled = false;
        DesactivatedLuxSecours();
    }
    void OnEnable()
    {
        Manager.firstBlackOut += TurnOffLights;
    }

    void OnDisable()
    {
        Manager.firstBlackOut -= TurnOffLights;
    }
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
        redLightFuses.enabled = false;
        DesactivatedLuxSecours();
        lightON = !(lightON);
        Fix();
    }
    private void TurnOffLights()
    {
        lightON =true;
        redLightFuses.enabled = true;
        ActivatedLuxSecours();
    }
    private void TurnOnLights()
    {
        lightON = false;
        
    }

    public void Fix()
    {
        Manager.blackOutFix = true;
    }
    public void ActivatedLuxSecours()
    {
        obj_1.SetActive(true);
        obj_2.SetActive(true);
        obj_3.SetActive(true);
        obj_4.SetActive(true);
        obj_5.SetActive(true);
        obj_6.SetActive(true);
        obj_7.SetActive(true);
    }
    public void DesactivatedLuxSecours()
    {
        obj_1.SetActive(false);
        obj_2.SetActive(false);
        obj_3.SetActive(false);
        obj_4.SetActive(false);
        obj_5.SetActive(false);
        obj_6.SetActive(false);
        obj_7.SetActive(false);
    }
}
