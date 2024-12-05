using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnnaManager : MonoBehaviour
{

    public static bool exitAnna;

    public GameObject identificationCanva;

    [SerializeField] private TMP_InputField usernameIF;
    [SerializeField] private TMP_InputField passwordIF;
    [SerializeField] private Button buttonValidation;

    private string myUsername = "anna";
    private string myPassword = "nana";

    private bool isValid;
    public static bool startIdentication;

    ///

    public GameObject searchCanva;

    public GameObject searchByAuthor; // 1
    public GameObject searchByCode; // 2
    public GameObject searchBygenre; // 3
    public GameObject searchByTitle; // 4
    public GameObject searchByYear; // 5

    [SerializeField] private TMP_InputField typeOfSearch;
    [SerializeField] private Button buttonTypeOfSearch;


    void Start()
    {
        identificationCanva.SetActive(false);
        searchCanva.SetActive(false);

        searchByAuthor.SetActive(false);
        searchByCode.SetActive(false);
        searchBygenre.SetActive(false);
        searchByTitle.SetActive(false);
        searchByYear.SetActive(false);
    }
    public void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {

            ExitAnna();
        }
        if (startIdentication && !exitAnna)
        {
            identificationCanva.SetActive(true);
            NavigateIdentification();
        }
        if (isValid)
        {
            searchCanva.SetActive(true);
            NavigationSelect();
        }
    }

    public void NavigateIdentification()
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
            buttonValidation.onClick.Invoke();
        }
    }
    public void ValidateInputs()
    {
        string username = usernameIF.text;
        string password = passwordIF.text;

        isValid = ValidateCredentials(username, password);
        Debug.Log(isValid ? "Validation réussie !" : "Échec de validation !");

        // stop la navigation de l'identifacation
        if (isValid)
        {
            identificationCanva.SetActive(false);
            startIdentication = false;
        }

    }

    private bool ValidateCredentials(string username, string password)
    {
        return username == myUsername && password == myPassword;
    }

    public void NavigationSelect()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            typeOfSearch.ActivateInputField();
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            buttonTypeOfSearch.onClick.Invoke();
        }
    }
    public void ChoosePlayer()
    {
        string select = typeOfSearch.text;
        select = select.Trim().ToLower();

        switch (select)
        {
             case "author":
                    searchByAuthor.SetActive(true);
                    break;
             case "code":
                    searchByCode.SetActive(true);
                    break;
             case "genre":
                    searchBygenre.SetActive(true);
                    break;
             case "title":
                    searchByTitle.SetActive(true);
                    break;
             case "year":
                    searchByYear.SetActive(true);
                    break;
             default:
                    Debug.Log("Option inconnue : " + select);
                    break;
            }
    }

    void ExitAnna()
    {
        exitAnna = true;

        identificationCanva.SetActive(false);
        searchCanva.SetActive(false);

        searchByAuthor.SetActive(false);
        searchByCode.SetActive(false);
        searchBygenre.SetActive(false);
        searchByTitle.SetActive(false);
        searchByYear.SetActive(false);

        usernameIF.text = string.Empty;
        passwordIF.text = string.Empty;
        isValid = false;

        typeOfSearch.text = string.Empty;

    }
}
