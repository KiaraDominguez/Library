using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PhoneCall : MonoBehaviour
{
    private Animator animator;
    public bool answerCall;
    ///public bool callDone;

    private bool phoneRinging;
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
        //if (phoneRinging)
        //{
            answerCall = !answerCall;
        //}
        
    }

    public void Call()
    {
        if (phoneRinging)
        {
            animator.SetBool("ringing", true);
        }

        if (answerCall)
        {
            animator.SetBool("answer", true);
        }
        if (!phoneRinging && !answerCall)
        {
            animator.SetBool("answer", false);
        }
    }

}
