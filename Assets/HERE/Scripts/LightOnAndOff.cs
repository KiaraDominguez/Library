using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LightOnAndOff : MonoBehaviour
{
    [SerializeField] Light luxGeneral;

    [SerializeField] Light lux;
    [SerializeField] Light redLightFuses;
    [SerializeField] Light redLightFusesCouloir1;
    [SerializeField] Light redLightFusesCouloir2;



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

    [SerializeField] GameObject radio;
    private AudioSource audioSource;

    [SerializeField] GameObject anna;

    void Start()
    {
        redLightFuses.enabled = false;
        redLightFusesCouloir1.enabled = false;
        redLightFusesCouloir2.enabled = false;

        DesactivatedLuxSecours();

        audioSource = radio.GetComponent<AudioSource>();
        
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
            luxGeneral.enabled = true;
        }
        else
        {
            fuse_Off.SetActive(true);
            fuse_On.SetActive(false);
            lux.enabled = false;
            luxGeneral.enabled = false;
        }
    }
    private void OnMouseDown()
    {
        redLightFuses.enabled = false;
        redLightFusesCouloir1.enabled = false;
        redLightFusesCouloir2.enabled = false;

        DesactivatedLuxSecours();
        lightON = !(lightON);
        Fix();
        audioSource.Play();
        
        anna.SetActive(true);
    }
    private void TurnOffLights()
    {
        anna.SetActive(false);

        lightON =true;

        redLightFuses.enabled = true;
        redLightFusesCouloir1.enabled = true;
        redLightFusesCouloir2.enabled = true;

        ActivatedLuxSecours();
        audioSource.Pause();
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
