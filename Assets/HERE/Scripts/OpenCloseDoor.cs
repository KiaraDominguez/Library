using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class OpenCloseDoor : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("canOpen", true);
        //animator.SetTrigger("open");
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("canOpen", false);
        //animator.SetTrigger("close");
    }

}
