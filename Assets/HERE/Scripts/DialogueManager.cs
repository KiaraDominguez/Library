using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    //permet d'accéder au dialogue manager

    public Image CharacterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    //référence pour les composents Ui dans unity

    private Queue<DialogueLine> lines;
    // ont choisit une queue et non une liste parce que queue.Enqueue() ajouter des élèment a la fin de la queue et Dequeue retire le premier élèment
    // donc le premier élément disparaitra plus vite que le dernier , plus facile pour lire

    public bool isDialogueActive;
    //dialogue active
    public float typingSpeed = 0.2f;
    //vitesse de frappe du text

    public CanvasGroup canvasGroup;

    private bool callBeenAnswer;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        lines = new Queue<DialogueLine>();
        
    }
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void OnEnable()
    {
        Manager.startDialogue += PhoneCallBeenAnswer;
    }
    void OnDisable()
    {
        Manager.startDialogue -= PhoneCallBeenAnswer;
    }

    public void PhoneCallBeenAnswer(bool okay)
    {
        callBeenAnswer = okay;
        Debug.Log($"bool de l'event dans DialogueManager : {okay}");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (callBeenAnswer)
        {
            // Ici je ne rentre pas dans le if
            Debug.Log("je rentre dans le if");
            isDialogueActive = true;

            lines.Clear();

            foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
            {
                lines.Enqueue(dialogueLine);
            }
            DisplayNextDialogueLine();
        }
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        CharacterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (Char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    void EndDialogue()
    {
        isDialogueActive = false;
    }

    void Update()
    {
        if (!isDialogueActive) 
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
    }
}

