using System.IO;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;
    private string username;
    private LeaderBoard leaderboard;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Initialize variables
        Instance = this;
        username = "Default";
        leaderboard = new LeaderBoard();

        // If savedata exists, load savedata and initialize variables using that


        DontDestroyOnLoad(gameObject);
    }
    
    // returns false if username is invalid
    public bool SetUsername(string username)
    {
        if ((username.Length < 2) || (username.Length > 12))
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

    public LeaderBoard GetLeaderboard()
    {
        return leaderboard;
    }
    
    public void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(leaderboard);
        File.WriteAllText(Application.persistentDataPath + "/leaderboard.json", json);
    }

    public bool LoadLeaderboard()
    {
        bool success = false;
        string path = Application.persistentDataPath + "/leaderboard.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            leaderboard = JsonUtility.FromJson<LeaderBoard>(json);
            success = true;
        }

        return success;
    }

    public void GenerateTestLeaderboard()
    {
        for (int i = 0; i < leaderboard.GetSize(); i++)
        {
            leaderboard.AddEntry("test name " + i, 5 * i);
        }
    }
}
    
    

