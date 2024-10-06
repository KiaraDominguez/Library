using System;
using UnityEngine;
using System.Collections;


public class Manager : MonoBehaviour
{
    public static event Action makeThePhoneRing;
    public static event Action callHasBeenAnswerStopTheRing;

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
            TriggerPhoneRinging();
        }
        if (Input.GetKeyDown(KeyCode.C)) // creer un script pour les dialogues npc quand le bouton de fin est presser par le player, ce script informera le manager qui lui informera phoneCall de lancer la fonction EndCall
        {
            TriggerStopTheRing();
        }
    }

    private void TriggerPhoneRinging()
    {
        if (makeThePhoneRing != null)
        {
            Debug.Log("Manager a declencher un appel");
            makeThePhoneRing.Invoke(); 
        }
    }
    private void TriggerStopTheRing()
    {
        
        if (callHasBeenAnswerStopTheRing != null)
        {
            Debug.Log("Manager a finit un appel");
            callHasBeenAnswerStopTheRing.Invoke();
            
        }
    }
}


