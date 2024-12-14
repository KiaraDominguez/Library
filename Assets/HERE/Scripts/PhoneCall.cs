using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PhoneCall : MonoBehaviour
{

    private Animator animator;

    private bool isRinging = false;
    private bool isAnswering = false;
    private bool isHangingUp = false;

    //BOOL POUR LE MANAGER//
    public bool phoneAnswer;

    public AudioClip sound;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        if (Input.GetMouseButtonDown(0)) // Vérifie le clic gauche
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform && isRinging) // Vérifie si l'objet cliqué est celui attendu
                {
                    AnswerPhone();
                }
            }
        }

    }

    public void StartRinging()
    {
        
        // Le téléphone commence à sonner
        isRinging = true;
        isAnswering = false;
        isHangingUp = false ;

        animator.SetBool("isRinging", true);
        animator.SetBool("isAnswering", false);
        animator.SetBool("isHangingUp", isHangingUp);

    }

    public void AnswerPhone()
    {
        //BOOL POUR LE MANAGER// (pour lui faire savoir que le player a répondu au téléphone)
        phoneAnswer = true;
        // L'utilisateur répond au téléphone

        isRinging = false;
        isAnswering = true;
        isHangingUp = false;

        animator.SetBool("isRinging", false);
        animator.SetBool("isAnswering", true);
        animator.SetBool("isHangingUp", isHangingUp);
    }

    public void HangUpPhone()
    {
        Debug.Log("hangUp");
        // Le manager raccroche le téléphone
        isRinging = false;
        isAnswering = false;
        isHangingUp = true;

        animator.SetBool("isRinging", false);
        animator.SetBool("isAnswering", false);
        animator.SetBool("isHangingUp", isHangingUp);
    }
    public void PlayRing()
    {
        audioSource.PlayOneShot(sound);
    }
    public void StopRing()
    {
        audioSource.Stop();
    }

}
