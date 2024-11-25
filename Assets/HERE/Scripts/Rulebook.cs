using UnityEngine;

public class Rulebook : MonoBehaviour
{
    private Animator animator;

    private bool isLit;
    private bool playerPickedIt;

    public CanvasGroup canvasGroup;
    private bool rulebookIsOpen;
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
        if(Input.GetKeyDown(KeyCode.B) && isLit) 
        {
            StopTheLit();
            animator.SetBool("lit", false);
            rulebookIsOpen = true;
        }
        if (!rulebookIsOpen)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && rulebookIsOpen)
        {
            rulebookIsOpen=false;
        }
    }

    public void MakeTheBookLit()
    {
        isLit = true;
        animator.SetBool("lit", isLit);
    }
    public void StopTheLit()
    {

        playerPickedIt = true;
        animator.SetBool("playerPickIt", playerPickedIt);
    }
}
