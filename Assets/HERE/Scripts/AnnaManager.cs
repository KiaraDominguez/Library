using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnnaManager : MonoBehaviour
{
    public bool firstBookOKAY;

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
    public GameObject search;
    public TextMeshProUGUI instruction;


    [SerializeField] private TMP_InputField typeOfSearch;
    [SerializeField] private Button buttonTypeOfSearch;

    private bool typeIsChoosed;

    [SerializeField] private TMP_InputField searchField;
    [SerializeField] private Button buttonSearchAuthor;

    private string firstAuthorName1 = "elias";
    private string firstAuthorName2 = "varnem";

    [SerializeField] TextMeshProUGUI books;
    public TextMeshProUGUI instruction_2;


    void Start()
    {
        identificationCanva.SetActive(false);
        searchCanva.SetActive(false);

        search.SetActive(false);

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
        if (typeIsChoosed)
        {
            searchCanva.SetActive(false);
            NavigationSearch();
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
                search.SetActive(true);
                instruction.text = "enter the author name";
                typeIsChoosed = true;
                //buttonSearchAuthor.interactable = true;
                break;
             case "code":
                search.SetActive(true);
                instruction.text = "enter the code";
                typeIsChoosed = true;

                break;
             case "genre":
                search.SetActive(true);
                instruction.text = "enter the genre";

                typeIsChoosed = true;

                break;
             case "title":
                search.SetActive(true);
                instruction.text = "enter the title";

                typeIsChoosed = true;

                break;
             case "year":
                search.SetActive(true);
                instruction.text = "enter the year of publication";
                typeIsChoosed = true;

                break;
             default:
                 Debug.Log("Option inconnue : " + select);
                 break;
            }
    }

    public void NavigationSearch()
    {

        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            searchField.ActivateInputField();
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            buttonSearchAuthor.onClick.Invoke();

        }
    }

    public void SearchByAuthor()
    {
        string name = searchField.text;
        name.ToLower().Trim();

        if(name==firstAuthorName1 || name == firstAuthorName2)
        {
            instruction.text = "Dr. Elias Varnem";
            books.text = ">> Rituals of Invocation Through the Ages: A Comparative Study";
            books.text += "\n>> The Forbidden Manuscripts: Studies on Texts Condemned by the Church";
            books.text += "\n>> The Science of Seals: Cryptographic and Spiritual Studies";

            instruction_2.text = string.Empty;
            searchField.text = string.Empty;

            firstBookOKAY = true;
            Manager.firstBookLocationUnlock = firstBookOKAY;
        }
    }
    void ExitAnna()
    {
        exitAnna = true;

        identificationCanva.SetActive(false);
        searchCanva.SetActive(false);

        search.SetActive(false);

        usernameIF.text = string.Empty;
        passwordIF.text = string.Empty;
        isValid = false;

        typeOfSearch.text = string.Empty;
        typeIsChoosed = false; 

    }
}
