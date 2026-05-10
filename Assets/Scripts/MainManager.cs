using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    private string username;
    private LeaderBoard leaderboard;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        if (PersistentData.Instance != null)
        {
            // Initialize variables using persistent data
            username = PersistentData.Instance.GetUsername();
            leaderboard = PersistentData.Instance.GetLeaderboard();
            PersistentData.Instance.LoadLeaderboard();
        }
        else
        {
            username = "No Name";
            // Initialize other variables
        }
        
        m_Points = 0;
        UpdateScoreText();
        InitializeLeaderBoardText();
        UpdateLeaderBoardText();
        SetupBricks();
    }

    private void InitializeLeaderBoardText()
    {
        // When game starts, create and fill out leaderboard
        for (int i = 0; i < leaderboard.GetSize(); i++)
        {
            // Make a text field for each leaderboard entry
        }
        
        
    }
    
    private void UpdateLeaderBoardText()
    {
        // Load leaderboard text from file
    }
    
    private void UpdateScoreText()
    {
        ScoreText.text = $"{username}\n Score : {m_Points}";
    }
    
    private void SetupBricks()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }
    
    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("mainMenu");
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        UpdateScoreText();
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
