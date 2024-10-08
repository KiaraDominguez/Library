using System;
using UnityEngine;
using System.Collections;
using UnityEditor.PackageManager;


public class Manager : MonoBehaviour
{
    public static event Action <bool> makeThePhoneRing;
    public static event Action startDialogue;

    public static event Action callHasBeenAnswerStopTheRing;

    public static event Action litRuleBook;

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
            phone.phoneAnswer = false;

        }
        if (DialogueManager.Instance.canIHungUp) 
        {
            TriggerStopTheRing();
            DialogueManager.Instance.canIHungUp = false;
            TriggerTheRuleBook();
        }
    }

    private void TriggerTheRuleBook()
    {
        if (litRuleBook != null)
        {
            Debug.Log("Manager a declencher un appel");
            litRuleBook.Invoke();
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


