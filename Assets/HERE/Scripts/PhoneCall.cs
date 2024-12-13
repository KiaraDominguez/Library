using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PhoneCall : MonoBehaviour
{

    private Animator animator;

    private bool isRinging = false;
    //private bool isAnswering = false;

    //BOOL POUR LE MANAGER//
    public bool phoneAnswer;

    void Start()
    {
        animator = GetComponent<Animator>();

    }
    void OnEnable()
    {
        Manager.makeThePhoneRing += StartRinging;
        Manager.callHasBeenAnswerStopTheRing += HangUpPhone;
    }

    void OnDisable()
    {
        Manager.makeThePhoneRing -= StartRinging;
        Manager.callHasBeenAnswerStopTheRing -= HangUpPhone;

    }
    
    void Update()
    
    {
        //répondre au téléphone avec la touche "B"
        //if (Input.GetKeyDown(KeyCode.B) && isRinging)
        //{
              //AnswerPhone();
        //}
    }
    private void OnMouseDown()
    {
        if (isRinging)
        {
            AnswerPhone();
        }
    }
    public void StartRinging(bool ringing)
    {
        // Le téléphone commence à sonner
        isRinging = ringing;
        //isAnswering = false;

        animator.SetBool("isRinging", ringing);
        animator.SetBool("isAnswering", false);
        animator.SetBool("isHangingUp", false);
    }

    public void AnswerPhone()
    {
        //BOOL POUR LE MANAGER// (pour lui faire savoir que le player a répondu au téléphone)
        phoneAnswer = true;
        // L'utilisateur répond au téléphone

        isRinging = false;
        //isAnswering = true;
        animator.SetBool("isRinging", false);
        animator.SetBool("isAnswering", true);
        animator.SetBool("isHangingUp", false);
    }

    public void HangUpPhone()
    {
        // Le manager raccroche le téléphone
        isRinging = false;
        //isAnswering = false;

        animator.SetBool("isRinging", false);
        animator.SetBool("isAnswering", false);
        animator.SetBool("isHangingUp", true);
    }

}
