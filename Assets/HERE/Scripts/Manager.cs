using System;
using UnityEngine;
using System.Collections;



public class Manager : MonoBehaviour
{
    //NPC
    [SerializeField] GameObject boss;
    [SerializeField] GameObject firstBook;


    //CALL BOSS//
    public static event Action <bool> makeThePhoneRing;
    public static event Action startDialogue;
    public static event Action callHasBeenAnswerStopTheRing;
    private bool startCallBoss;
    private GameObject other;
    private PhoneCall phone;
    private bool phoneAnswer;
    //txt phone
    public Canvas canvasPhone;

    //RULEBOOK LU //
    private GameObject obj;
    private Rulebook rule;
    private bool rulebookRead;

    //SURBRILLANCE DU RULEBOOK//
    public static event Action litRuleBook;
    //txt rulebook
    public Canvas canvasRulebook;

    // BLACK-OUT
    public static event Action firstBlackOut;
    private bool firstBlackOutReady;
    public static bool blackOutFix;

    // FIRST BOOK

    [SerializeField] bool firstBookLocationUnlock;

    void Start()
    {
        //CALL BOSS//
        other = GameObject.FindWithTag("phone");
        phone = other.GetComponent<PhoneCall>();
        StartCoroutine(MyCoroutine());
        //txt phone
        canvasPhone.gameObject.SetActive(false);

        //RULEBOOK LU //
        obj = GameObject.FindWithTag("rulebook");
        rule=obj.GetComponent<Rulebook>();
        
        //txt rulebook
        canvasRulebook.gameObject.SetActive(false);

        // FIRST BOOK
        firstBookLocationUnlock = AnnaManager.firstBookOKAY;
    }

    IEnumerator MyCoroutine()
    {
        //CALL BOSS//
        yield return new WaitForSeconds(1);
        startCallBoss = true;
    }

    IEnumerator CoroutineFirstBlackOut()
    {
        yield return new WaitForSeconds(2);
        rule.rulebookHasBeenRaed = false;
        TriggerBlackOut();
    }
    void Update()
    {
        //CALL BOSS//
        phoneAnswer = phone.phoneAnswer;

        if (startCallBoss)
        {
            TriggerPhoneRinging(true);

            canvasPhone.gameObject.SetActive(true);

        }
        if (phoneAnswer)
        {
            TriggerStartDialogue();
            phone.phoneAnswer = false;
            startCallBoss = false;

            canvasPhone.gameObject.SetActive(false);

        }
        if (DialogueManager.Instance.canIHungUp) 
        {
            TriggerStopTheRing();
            DialogueManager.Instance.canIHungUp = false;

            if (!blackOutFix) 
            {
                //SURBRILLANCE DU RULEBOOK//
                TriggerTheRuleBook();
                canvasRulebook.gameObject.SetActive(true);
            }
            
        }
        //RULEBOOK LU //
        rulebookRead = rule.rulebookHasBeenRaed;
        if (rulebookRead) 
        {
            StartCoroutine(CoroutineFirstBlackOut());

            canvasRulebook.gameObject.SetActive(false);

        }
        if (blackOutFix)
        {
            boss.SetActive(false);
            TriggerPhoneRinging(true);
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


