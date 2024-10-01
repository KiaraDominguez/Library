using System;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public static event Action call;
    public static event Action endCall;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // condition de test pour le moment
        {
            Triggercall();
        }
        if (Input.GetKeyDown(KeyCode.V)) // condition de test pour le moment
        {
            TriggerEndCall();
        }
    }

    private void Triggercall()
    {
        if (call != null)
        {
            Debug.Log("Manager a declencher un appel");
            call.Invoke(); 
        }
    }
    private void TriggerEndCall()
    {
        if (endCall != null)
        {
            Debug.Log("Manager a finit un appel");
            endCall.Invoke();
        }
    }


}


