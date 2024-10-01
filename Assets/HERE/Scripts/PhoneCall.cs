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
        Manager.call += IncomingCall;
        Manager.endCall += EndCall;

    }

    void OnDisable()
    {
        Manager.call -= IncomingCall;
        Manager.endCall -= EndCall;

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

    public void EndCall()
    {
        phoneRinging = false;
        animator.SetBool("ringing", false);
    }

}
