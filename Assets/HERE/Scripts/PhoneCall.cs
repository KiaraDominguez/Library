using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PhoneCall : MonoBehaviour
{
    private Animator animator;
    public bool answerCall;
    ///public bool callDone;

    public bool phoneRinging;

    void OnEnable()
    {
        Manager.makeThePhoneRing += IncomingCall;
        Manager.callHasBeenAnswerStopTheRing += CallHasBeenAnswer;

    }

    void OnDisable()
    {
        Manager.makeThePhoneRing -= IncomingCall;
        Manager.callHasBeenAnswerStopTheRing -= CallHasBeenAnswer;

    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Call();
    }

    private void OnMouseDown()
    {
        answerCall = !answerCall;
        
    }

    public void Call()
    {
        if (answerCall)
        {
            animator.SetBool("answer", true);
        }
        if (!phoneRinging && !answerCall)
        {
            animator.SetBool("answer", false);
        }
    }

    public void IncomingCall()
    {
        animator.SetBool("ringing", true);
    }

    public void CallHasBeenAnswer()
    {
        phoneRinging = false;
        animator.SetBool("ringing", false);
        Debug.Log("EVENT FONCTIONNE");
    }

}
