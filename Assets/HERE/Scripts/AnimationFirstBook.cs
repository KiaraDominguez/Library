using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFirstBook : MonoBehaviour
{
    public bool isLit;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }
    void OnEnable()
    {
        Manager.firstBookLit += MakeTheBookLit;
    }

    void OnDisable()
    {
        Manager.firstBookLit -= MakeTheBookLit;
    }

    void Update()
    {
        //if (RayCast.playerSawBook ==1 )
        //{
            //StopTheLit();
        //}
    }

    public void MakeTheBookLit()
    {
        Debug.Log("TriggerFirstBookLit");
        animator.SetBool("TouchByRayCast", true);
    }
    public void StopTheLit()
    {
        animator.SetBool("TouchByRayCast", false);

    }
}
