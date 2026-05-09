using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TextMeshProUGUI invalidUsernameText;
    
    private string username;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invalidUsernameText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked()
    {
        string newUsername = usernameField.text;
        if (PersistentData.Instance.SetUsername(newUsername))
        {
            SceneManager.LoadScene("main");
        }
        else
        {
            // username is invalid. Prompt user to fix username
            invalidUsernameText.enabled = true;
        }
    }

    public void ExitButtonClicked()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
