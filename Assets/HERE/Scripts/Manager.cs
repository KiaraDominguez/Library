using System;
using UnityEngine;
using System.Collections;


public class Manager : MonoBehaviour
{
    public static event Action <bool> makeThePhoneRing;
    public static event Action<bool> startDialogue;
    // changer en event action simple
    public static event Action callHasBeenAnswerStopTheRing;

    private GameObject other;
    private PhoneCall phone;
    private bool phoneAnswer;

    private bool startCallBoss;

    ////// avec timer///////
    //private float timer = 0f;
    //private float waitTime = 5f;
    //private bool isWaiting = false;
    void Start()
    {
        other = GameObject.FindWithTag("phone");
        phone = other.GetComponent<PhoneCall>();

        ////// avec timer///////
        //isWaiting = true;

        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1);
        startCallBoss = true;
    }

    void Update()
    {
        ////// avec timer///////
        //if (isWaiting)
        //{
        //    timer += Time.deltaTime;
        //    if (timer >= waitTime)
        //    {
        //        startCallBoss = true;
        //        isWaiting = false;  // Arrêter le timer
        //    }
        //}
        phoneAnswer = phone.phoneAnswer;

        if (startCallBoss)
        {
            TriggerPhoneRinging(true);
        }
        if (phoneAnswer)
        {
            Debug.Log("phoneAnswer");
            TriggerStartDialogue(true);
        }
        if (Input.GetKeyDown(KeyCode.C) ) // creer un script pour les dialogues npc quand le bouton de fin est presser par le player, ce script informera le manager qui lui informera phoneCall de lancer la fonction EndCall
        {
            TriggerStopTheRing();
        }
    }

    private void TriggerStartDialogue(bool dialogue)
    {
        if (startDialogue != null)
        {
            Debug.Log("DialogueManager a commencer un dialogue");
            startDialogue.Invoke(dialogue);
        }
    }

    private void TriggerPhoneRinging(bool ringing)
    {
        if (makeThePhoneRing != null)
        {
            Debug.Log("Manager a declencher un appel");
            makeThePhoneRing.Invoke(ringing); 
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


