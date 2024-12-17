using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationThirdBook : MonoBehaviour
{
    public bool isLit;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }
    void OnEnable()
    {
        Manager.thirdBookLit += MakeTheBookLit;
    }

    void OnDisable()
    {
        Manager.thirdBookLit -= MakeTheBookLit;
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
        animator.SetBool("TouchByRayCast", true);
    }
    public void StopTheLit()
    {
        animator.SetBool("TouchByRayCast", false);

    }
}
