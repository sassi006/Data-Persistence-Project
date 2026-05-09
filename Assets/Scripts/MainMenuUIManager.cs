using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButtonClicked()
    {
        SceneManager.LoadScene("main");
    }

    public void exitButtonClicked()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
