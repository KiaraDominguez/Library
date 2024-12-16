using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Scare : MonoBehaviour
{
    public Transform player;

    public GameObject face;
    public GameObject body;

    private Color faceOriginalColor;
    private Color bodyOriginalColor;

    private SkinnedMeshRenderer faceSkinnedMeshRenderer;
    private SkinnedMeshRenderer bodySkinnedMeshRenderer;

    private bool playerSawItOnce;

    [SerializeField] GameObject lightGeneral;
    private Animator animator;

    private AudioSource audioSource;

    private IEnumerator DesactivateLight(float seconds)
    {
        yield return new WaitForSeconds(0.25f);
        lightGeneral.SetActive(false);
        yield return new WaitForSeconds(seconds);
        lightGeneral.SetActive(true);
        
    }

    public void StartAnimationCoroutine()
    {
        StartCoroutine(DesactivateLight(1.75f));
    }
    void Start()
    {
        faceSkinnedMeshRenderer = face.GetComponent<SkinnedMeshRenderer>();
        faceOriginalColor = faceSkinnedMeshRenderer.material.color;

        bodySkinnedMeshRenderer = body.GetComponent<SkinnedMeshRenderer>();
        bodyOriginalColor = bodySkinnedMeshRenderer.material.color;

        SetObjectVisibility(false);

        animator = lightGeneral.GetComponent<Animator>();
        audioSource = lightGeneral.GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerSawItOnce) 
        {
            PlayRing();
            SetObjectVisibility(true);
            animator.SetTrigger("scare");
            //TemporarilyDeactivate();
        }
        playerSawItOnce = true;

    }

    public void OnTriggerExit(Collider other)
    {
        StopRing();
        SetObjectVisibility(false);
    }

    // Update is called once per frame
    private void SetObjectVisibility(bool isVisible)
    {
        if (isVisible)
        {
            faceSkinnedMeshRenderer.material.color = faceOriginalColor;
            bodySkinnedMeshRenderer.material.color = bodyOriginalColor;
        }
        else
        {
            faceSkinnedMeshRenderer.material.color = new Color(faceOriginalColor.r, faceOriginalColor.g, faceOriginalColor.b, 0f); // Rendre transparent
            bodySkinnedMeshRenderer.material.color = new Color(bodyOriginalColor.r, bodyOriginalColor.g, bodyOriginalColor.b, 0f); // Rendre transparent
        }
    }

    public void PlayRing()
    {
        audioSource.Play();
    }
    public void StopRing()
    {
        audioSource.Stop();
    }
}
