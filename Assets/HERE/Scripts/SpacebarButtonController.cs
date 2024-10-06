using UnityEngine.UI;
using UnityEngine;

public class SpacebarButtonController : MonoBehaviour
{
    public Button myButton;
    public DialogueManager dialogueManager;

    void Update()
    {
        if (dialogueManager.isDialogueActive)
        {
            Debug.Log("Ok");
            // Détecter si la barre d'espace est pressée
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Vérifier si le bouton est assigné et l'activer
                if (myButton != null)
                {
                    myButton.onClick.Invoke();  // Appeler le OnClick manuellement
                }
            }
        }
        
    }

    // La méthode appelée lorsque le bouton est cliqué ou que la barre d'espace est pressée
    void OnButtonClicked()
    {
        Debug.Log("Bouton activé par la barre d'espace ou un clic !");
        // Ajouter votre logique ici, par exemple, changer de scène ou lancer une action.
    }
}

