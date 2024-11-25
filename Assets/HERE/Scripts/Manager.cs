using System;
using UnityEngine;
using System.Collections;
using UnityEditor.PackageManager;
using TMPro;
using System.Data;


public class Manager : MonoBehaviour
{
    //CALL BOSS//
    public static event Action <bool> makeThePhoneRing;
    public static event Action startDialogue;
    public static event Action callHasBeenAnswerStopTheRing;
    private bool startCallBoss;
    private GameObject other;
    private PhoneCall phone;
    private bool phoneAnswer;

    //RULEBOOK LU //
    private GameObject obj;
    private Rulebook rule;
    private bool rulebookRead;

    //SURBRILLANCE DU RULEBOOK//
    public static event Action litRuleBook;

    // BLACK-OUT
    public static event Action firstBlackOut;
    private bool firstBlackOutReady;

    void Start()
    {
        //CALL BOSS//
        other = GameObject.FindWithTag("phone");
        phone = other.GetComponent<PhoneCall>();
        StartCoroutine(MyCoroutine());

        //RULEBOOK LU //
        obj = GameObject.FindWithTag("rulebook");
        rule=obj.GetComponent<Rulebook>();
    }

    IEnumerator MyCoroutine()
    {
        //CALL BOSS//
        yield return new WaitForSeconds(1);
        startCallBoss = true;
    }

    IEnumerator CoroutineFirstBlackOut()
    {
        yield return new WaitForSeconds(1);
        firstBlackOutReady = true;
    }
    void Update()
    {
        //CALL BOSS//
        phoneAnswer = phone.phoneAnswer;

        if (startCallBoss)
        {
            TriggerPhoneRinging(true);
        }
        if (phoneAnswer)
        {
            TriggerStartDialogue();
            phone.phoneAnswer = false;
            startCallBoss = false;

        }
        if (DialogueManager.Instance.canIHungUp) 
        {
            TriggerStopTheRing();
            DialogueManager.Instance.canIHungUp = false;
            //SURBRILLANCE DU RULEBOOK//
            TriggerTheRuleBook();
        }
        //RULEBOOK LU //
        rulebookRead = rule.rulebookHasBeenRaed;
        if (rulebookRead && firstBlackOutReady) 
        {
            rule.rulebookHasBeenRaed = false;
            TriggerBlackOut();
            firstBlackOutReady = false;
        }
    }

    //SURBRILLANCE DU RULEBOOK//
    private void TriggerTheRuleBook()
    {
        if (litRuleBook != null)
        {
            litRuleBook.Invoke();
        }
    }
    // BLACK-OUT
    private void TriggerBlackOut()
    {
        if(firstBlackOut != null)
        {
            firstBlackOut.Invoke();
        }
    }

    //CALL BOSS//
    private void TriggerStartDialogue()
    {
        if (startDialogue != null)
        {
            startDialogue.Invoke();
        }
    }

    private void TriggerPhoneRinging(bool ringing)
    {
        if (makeThePhoneRing != null)
        {
            makeThePhoneRing.Invoke(ringing); 
        }
    }
    private void TriggerStopTheRing()
    {
        
        if (callHasBeenAnswerStopTheRing != null)
        {
            callHasBeenAnswerStopTheRing.Invoke();
        }
    }
}


