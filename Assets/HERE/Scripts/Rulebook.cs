using UnityEngine;

public class Rulebook : MonoBehaviour
{
    private Animator animator;

    private bool isLit;
    private bool playerPickedIt;

    public CanvasGroup canvasGroup;
    private bool rulebookIsOpen;
    public bool rulebookHasBeenRaed;
    private int count = 0;
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
        if(Input.GetKeyDown(KeyCode.R) && isLit) 
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
            count++;
            rulebookIsOpen=false;
            FirstTimeRead();
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
    public void FirstTimeRead()
    {
        if(count == 1)
        {
            rulebookHasBeenRaed = true;
        }
    }
}
