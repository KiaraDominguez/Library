using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnnaManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameIF;
    [SerializeField] private TMP_InputField passwordIF;
    [SerializeField] private Button myButton;

    private string myUsername = "anna";
    private string myPassword = "nana";

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            usernameIF.ActivateInputField();
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            passwordIF.ActivateInputField();
        }
        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            myButton.onClick.Invoke();
        }
    }
    public void ValidateInputs()
    {
        string username = usernameIF.text;
        string password = passwordIF.text;

        bool isValid = ValidateCredentials(username, password);
        Debug.Log(isValid ? "Validation réussie !" : "Échec de validation !");

    }

    private bool ValidateCredentials(string username, string password)
    {
        return username == myUsername && password == myPassword;
    }
}
