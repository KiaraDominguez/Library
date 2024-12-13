using System;
using UnityEngine;
using System.Collections;
using TMPro;



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

    //RULEBOOK LU //
    private GameObject obj;
    private Rulebook rule;
    private bool rulebookRead;

    //SURBRILLANCE DU RULEBOOK//
    public static event Action litRuleBook;

    // BLACK-OUT
    public static event Action firstBlackOut;
    private bool firstBlackOutReady;
    public static bool blackOutFix;

    // FIRST BOOK

    public static bool firstBookLocationUnlock;
    public static bool playerSeeFirstBook = true;
    public static event Action firstBookLit;

    //MISSIONS
    public TextMeshProUGUI mission;
    private string txtphone = "Répond au téléphone";
    private string txtrulebook = "Lis le réglèment d'intérieur";
    private string txtblackout = "Trouve et active le disjoncteur";
    private string txtfirstbook = "Trouve un moyen de localiser le Lire du Dr. Elias";


    void Start()
    {
        //CALL BOSS//
        other = GameObject.FindWithTag("phone");
        phone = other.GetComponent<PhoneCall>();
        StartCoroutine(MyCoroutine());

        //RULEBOOK LU //
        obj = GameObject.FindWithTag("rulebook");
        rule=obj.GetComponent<Rulebook>();

        firstBook.SetActive(false);

        //txt mission phone
        mission.text = txtphone;

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
        mission.text = txtblackout;
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

            if (!blackOutFix) 
            {
                //SURBRILLANCE DU RULEBOOK//
                TriggerTheRuleBook();
                mission.text = txtrulebook;
            }
            
        }
        //RULEBOOK LU //
        rulebookRead = rule.rulebookHasBeenRaed;
        if (rulebookRead) 
        {
            StartCoroutine(CoroutineFirstBlackOut());

        }
        if (blackOutFix)
        {
            boss.SetActive(false);
            firstBook.SetActive(true);
            TriggerPhoneRinging(true);
            mission.text = txtfirstbook;
        }

        // FIRST BOOK
        
        if (firstBookLocationUnlock && playerSeeFirstBook) 
        {
            Debug.Log("TriggerFirstBookLit");
            TriggerFirstBookLit();
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

    private void TriggerFirstBookLit()
    {
        if (firstBookLit != null)
        {
            firstBookLit.Invoke();
        }
    }

}


