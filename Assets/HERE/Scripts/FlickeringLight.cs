using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light redLight;

    void Start()
    {
        redLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flickering()
    {
        redLight.enabled = false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Flickering();
    }
}
