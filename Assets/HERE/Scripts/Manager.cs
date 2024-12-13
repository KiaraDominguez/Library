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
    public static event Action makeThePhoneRing;
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
    public static bool playerSeeFirstBook;
    public static event Action firstBookLit;

    //MISSIONS
    public TextMeshProUGUI mission;
    private string txtphone = "Répond au téléphone";
    private string txtrulebook = "Lis le réglèment d'intérieur";
    private string txtblackout = "Trouve et active le disjoncteur";
    private string txtfirstbook = "Trouve un moyen de localiser le Lire du Dr. Elias";
    private string txtfirstbookLocation = "::::";
    private string txtinstructionEspace = "appuie sur ESPACE pour le mettre en réserve";

    // jumpscare

    public static event Action jumpscare;


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
        CallBoss();

        //RULEBOOK LU //
        rulebookRead = rule.rulebookHasBeenRaed;
        if (rulebookRead) 
        {
            StartCoroutine(CoroutineFirstBlackOut());

        }
        if (blackOutFix)
        {
            // ICI JUMPSCARE
            TriggerJumpscare();

            boss.SetActive(false);
            firstBook.SetActive(true);
            //TriggerPhoneRinging();
            mission.text = txtfirstbook;
        }

        // FIRST BOOK
        if(firstBookLocationUnlock) mission.text = txtfirstbookLocation;

        if (firstBookLocationUnlock && playerSeeFirstBook) 
        {
            Debug.Log("TriggerFirstBookLit");
            TriggerFirstBookLit();
            mission.text = txtinstructionEspace;
        }

    }
    private void TriggerJumpscare() 
    {
        if (jumpscare != null)
        {
            jumpscare.Invoke();
        }
    }
    public void CallBoss()
    {
        //CALL BOSS//
        phoneAnswer = phone.phoneAnswer;

        if (startCallBoss)
        {
            TriggerPhoneRinging();
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

    private void TriggerPhoneRinging()
    {
        if (makeThePhoneRing != null)
        {
            makeThePhoneRing.Invoke(); 
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


