using System;
using UnityEngine;
using System.Collections;


public class Manager : MonoBehaviour
{
    public static event Action <bool> makeThePhoneRing;
    public static event Action startDialogue;
    // changer en event action simple
    public static event Action callHasBeenAnswerStopTheRing;

    private GameObject other;
    private PhoneCall phone;
    private bool phoneAnswer;

    private bool startCallBoss;
    void Start()
    {
        other = GameObject.FindWithTag("phone");
        phone = other.GetComponent<PhoneCall>();

        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1);
        startCallBoss = true;
    }

    void Update()
    {
        phoneAnswer = phone.phoneAnswer;

        if (startCallBoss)
        {
            TriggerPhoneRinging(true);
        }
        if (phoneAnswer)
        {
            Debug.Log("phoneAnswer");
            TriggerStartDialogue();
        }
        if (DialogueManager.Instance.canIHungUp) 
        {
            TriggerStopTheRing();
        }
    }

    private void TriggerStartDialogue()
    {
        if (startDialogue != null)
        {
            Debug.Log("DialogueManager a commencer un dialogue");
            startDialogue.Invoke();
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


