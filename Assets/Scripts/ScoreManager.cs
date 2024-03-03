using System;

public class ScoreManager
{
    private static ScoreManager m_Instance;

    public static ScoreManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new ScoreManager();
            }

            return m_Instance;
        }
    }

    public event Action OnAddScore;

    public int Score { get; private set; }

    private static int totalScore = 1;

    public void AddScore()
    {
        Score++;
        if (OnAddScore != null)
        {
            OnAddScore();
        }
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public static int GetTotalScore()
    {
        return totalScore;
    }

    public static void IncrementTotalScore()
    {
        totalScore++;
    }

    public static void ResetTotalScore()
    {
        totalScore = 0;
    }
}
