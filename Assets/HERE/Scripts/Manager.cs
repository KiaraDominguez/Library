using System;
using UnityEngine;
using System.Collections;


public class Manager : MonoBehaviour
{
    public static event Action call;
    public static event Action endCall;

    private bool startCallBoss;
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5);
        startCallBoss = true;
    }

    void Update()
    {
        if (startCallBoss)
        {
            Triggercall();
        }
        if (Input.GetKeyDown(KeyCode.V)) // creer un script pour les dialogues npc quand le bouton de fin est presser par le player, ce script informera le manager qui lui informera phoneCall de lancer la fonction EndCall
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


