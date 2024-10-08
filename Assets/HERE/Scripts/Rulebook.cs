using UnityEngine;

public class Rulebook : MonoBehaviour
{
    private Animator animator;

    private bool isLit;
    private bool playerPickedIt;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        Manager.litRuleBook += MakeTheBookLit;
    }

    void OnDisable()
    {
        Manager.litRuleBook -= MakeTheBookLit;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && isLit) 
        {
            StopTheLit();
        }
    }

    public void MakeTheBookLit()
    {
        isLit = true;
        playerPickedIt = false;

        animator.SetBool("lit", isLit);
        animator.SetBool("playerPickIt", playerPickedIt);
    }
    public void StopTheLit()
    {
        isLit = true;
        playerPickedIt = true;

        animator.SetBool("lit", isLit);
        animator.SetBool("playerPickIt", playerPickedIt);
    }
}
