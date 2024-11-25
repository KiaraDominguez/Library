using System;
using UnityEngine;
using System.Collections;
using UnityEditor.PackageManager;
using TMPro;


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
    // pour le texte
    public TextMeshProUGUI textPhone;

    //SURBRILLANCE DU RULEBOOK//
    public static event Action litRuleBook;
    
    void Start()
    {
        //CALL BOSS//
        other = GameObject.FindWithTag("phone");
        phone = other.GetComponent<PhoneCall>();
        StartCoroutine(MyCoroutine());
        textPhone.color = new Color(textPhone.color.r, textPhone.color.g, textPhone.color.b, 0);
    }

    IEnumerator MyCoroutine()
    {
        //CALL BOSS//
        yield return new WaitForSeconds(1);
        startCallBoss = true;
    }

    void Update()
    {
        //CALL BOSS//
        phoneAnswer = phone.phoneAnswer;

        if (startCallBoss)
        {
            TriggerPhoneRinging(true);
            textPhone.color = new Color(textPhone.color.r, textPhone.color.g, textPhone.color.b, 1);
        }
        if (phoneAnswer)
        {
            Debug.Log("phoneAnswer");
            TriggerStartDialogue();
            phone.phoneAnswer = false;
            startCallBoss = false;
            textPhone.color = new Color(textPhone.color.r, textPhone.color.g, textPhone.color.b, 0);

        }
        if (DialogueManager.Instance.canIHungUp) 
        {
            TriggerStopTheRing();
            DialogueManager.Instance.canIHungUp = false;
            //SURBRILLANCE DU RULEBOOK//
            TriggerTheRuleBook();
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


