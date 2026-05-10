using UnityEngine;

[System.Serializable]
public class LeaderBoard
{
    [SerializeField] private LeaderBoardEntry[] leaderboardArray;

    public LeaderBoard()
    {
        leaderboardArray = new LeaderBoardEntry[5];
        InitLeaderboard();
    }
    
    public LeaderBoard(int leaderboardSize)
    {
        leaderboardArray = new LeaderBoardEntry[leaderboardSize];
        InitLeaderboard();
    }

    private void InitLeaderboard()
    {
        for (int i = 0; i < leaderboardArray.Length; i++)
        {
            leaderboardArray[i] = new LeaderBoardEntry();
        }
    }
    
    public int GetSize()
    {
        return leaderboardArray.Length;
    }
    
    // Add an entry to the leaderboard. If all entries in the leaderboard are higher than the current entry,
    // no changes will be made.
    public void AddEntry(string name, int score)
    {
        LeaderBoardEntry newEntry = new LeaderBoardEntry(name, score); // The entry to add
        LeaderBoardEntry tempContainer = new LeaderBoardEntry(); // A container for copying existing entries
        
        // Iterate through the entire leaderboard and insert the new entry where appropriate
        for (int index = 0; index < leaderboardArray.Length; index++)
        {
            if (newEntry.GetScore() >= leaderboardArray[index].GetScore() )
            {
                tempContainer = leaderboardArray[index];
                leaderboardArray[index] = newEntry;
                newEntry = tempContainer;
            }
        }
    }
}

[System.Serializable]
class LeaderBoardEntry
{
    [SerializeField] private string name;
    [SerializeField] private int score;

    public LeaderBoardEntry()
    {
        name = "____";
        score = 0;
    }

    public LeaderBoardEntry(string username, int userScore)
    {
        name = username;
        score = userScore;
    }

    public void SetName(string newName)
    {
        name = newName;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }

    public string GetName()
    {
        return name;
    }

    public int GetScore()
    {
        return score;
    }
}
