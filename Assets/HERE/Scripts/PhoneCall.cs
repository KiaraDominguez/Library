using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PhoneCall : MonoBehaviour
{
    private Animator animator;
    public bool calling;
    public bool callDone;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (calling) 
        {
            animator.SetBool("calling",true);
            calling = false;
        }
        if (callDone) 
        {
            animator.SetBool("calling", false);
            callDone = false;
        }
    }
}
