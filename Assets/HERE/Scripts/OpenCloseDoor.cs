using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class OpenCloseDoor : MonoBehaviour
{
    private Animator animator;
    public bool open;
    public bool close;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            animator.SetBool("canOpen", true);
            open = false;
        }
        if (close)
        {
            animator.SetBool("canOpen", false);
            close = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        open = true;
    }

    private void OnTriggerExit(Collider other)
    {
       close = true;
    }

}
