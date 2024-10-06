using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
    //Contient nom et photo du personnage qui parle
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
    //va utiliser la class DialogueCharacter
}
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
    //Liste des lignes de dialogue pour la conversation
}
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool callBeenAnswer = false;

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
        //TriggerDialogue();
        Debug.Log($"bool de l'event dans DialogueTrigger : {okay}");

    }

    void Update()
    {
        if (callBeenAnswer)
        {
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        Debug.Log("rentre dans le TriggerDialogue}");
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}