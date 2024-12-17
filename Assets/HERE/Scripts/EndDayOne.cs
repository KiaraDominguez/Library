using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndDayOne : MonoBehaviour
{
    public static int score = 0;
    public CanvasGroup canvasGroup;
    private AudioSource audioSource;

    private bool isCoroutineRunning = false;

    [SerializeField] GameObject radio;
    private AudioSource audioRadio;
    void Start()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        audioSource = GetComponent<AudioSource>();
        audioRadio = radio.GetComponent<AudioSource>();
    }
    IEnumerator CoroutineFin()
    {
        audioSource.Play();
        yield return new WaitForSeconds(16);
        audioRadio.Stop();
        TheEnd();
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (score == 3 && !isCoroutineRunning)
        {
            Debug.Log("Fin");
            isCoroutineRunning = true;
            StartCoroutine(CoroutineFin());
        }
    }
    public void TheEnd()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}

