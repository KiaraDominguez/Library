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

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
            //TriggerDialogue();
        //}
    }
}