using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;
    private string username;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // returns false if username is invalid
    public bool SetUsername(string username)
    {
        if ((username.Length < 2)||(username.Length > 12))
        {
            // invalid username
            return false;
        }
        
        this.username = username;
        return true;
    }

    public string GetUsername()
    {
        return username;
    }
}

