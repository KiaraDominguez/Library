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
        if(Input.GetKeyDown(KeyCode.V) && isLit) 
        {
            StopTheLit();
            animator.SetBool("lit", false);
        }
    }

    public void MakeTheBookLit()
    {
        isLit = true;
        animator.SetBool("lit", isLit);
    }
    public void StopTheLit()
    {
        Debug.Log("je rentrre dans Stop the lit");

        playerPickedIt = true;
        animator.SetBool("playerPickIt", playerPickedIt);
    }
}
