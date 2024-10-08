using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PhoneCall : MonoBehaviour
{

    private Animator animator;

    public bool phoneAnswer;

    private bool isRinging = false;
    private bool isAnswering = false;
    private bool isHangingUp = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        Manager.makeThePhoneRing += StartRinging;
        Manager.callHasBeenAnswerStopTheRing += HangUpPhone;
    }

    void OnDisable()
    {
        Manager.makeThePhoneRing -= StartRinging;
        Manager.callHasBeenAnswerStopTheRing -= HangUpPhone;

    }
    void Update()
    {

        //répondre au téléphone avec la touche "A"
        if (Input.GetKeyDown(KeyCode.A) && isRinging)
        {
            AnswerPhone();
        }
    }
    public void StartRinging(bool ringing)
    {
        // Le téléphone commence à sonner
        isRinging = ringing;
        isAnswering = false;
        isHangingUp = false;

        animator.SetBool("isRinging", ringing);
        animator.SetBool("isAnswering", false);
        animator.SetBool("isHangingUp", false);
    }

    public void AnswerPhone()
    {
        // pour le manager, pour lui faire savoir que le player a répondu au téléphone
        phoneAnswer = true;
        // L'utilisateur répond au téléphone
        isRinging = false;
        isAnswering = true;
        isHangingUp = false;

        animator.SetBool("isRinging", false);
        animator.SetBool("isAnswering", true);
        animator.SetBool("isHangingUp", false);
    }

    public void HangUpPhone()
    {
        // L'utilisateur raccroche le téléphone
        isRinging = false;
        isAnswering = false;
        isHangingUp = true;

        animator.SetBool("isRinging", false);
        animator.SetBool("isAnswering", false);
        animator.SetBool("isHangingUp", true);
    }

}
