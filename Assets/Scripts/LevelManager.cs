using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs; // Table of prefabs for different levels
    public float fadeDuration = 1f; // Fade transition time
    public float goalPointsForLevel1 = 1; // Number of GoalPoint for level 1

    private int m_CurrentLevelIndex = 0; // Current level index
    private GameObject m_CurrentLevelInstance; // Current level instance
    private bool isTransitioning = false; // Indicates whether a level transition is in progress

    private void Start()
    {
        LoadLevel(0);
    }

    private void Update()
    {
        // Checks if the score is sufficient to move on to the next level
        if (!isTransitioning && ScoreManager.Instance.Score >= goalPointsForLevel1 * (m_CurrentLevelIndex + 1))
        {
            LoadNextLevel();
        }
    }

    private void LoadLevel(int levelIndex)
    {
        // Delete the current level if it already exists
        if (m_CurrentLevelInstance != null)
        {
            Destroy(m_CurrentLevelInstance);
        }

        ScoreManager.Instance.ResetScore();

        ScoreManager.IncrementTotalScore();

        Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);

        // Set new level
        m_CurrentLevelInstance = Instantiate(levelPrefabs[levelIndex], Vector3.zero, rotation);

        TeleportPlayerToInitialPosition();
    }

    private void TeleportPlayerToInitialPosition()
{
    GameObject player = GameObject.FindWithTag("Player");

    if (player != null)
    {
        player.transform.position = new Vector3(0.32f, 1f, -2.49f);
    }
}

    public void LoadNextLevel()
    {
        if (m_CurrentLevelIndex < levelPrefabs.Length - 1)
        {
            StartCoroutine(TransitionToNextLevel());
            m_CurrentLevelIndex++;
        }
        else
        {
            Debug.Log("Bravo, vous avez terminé le jeu");
        }
    }

    private IEnumerator TransitionToNextLevel()
    {
        isTransitioning = true;

        // Reduce scene opacity to zero with a fade transition
        yield return FadeScene();

        LoadLevel(m_CurrentLevelIndex);

        isTransitioning = false;
    }

    private IEnumerator FadeScene()
    {
        float elapsedTime = 0f;
        Color originalColor = Color.black;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            // Update background color
            RenderSettings.fogColor = Color.Lerp(originalColor, targetColor, elapsedTime / fadeDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Make sure the background color is exactly the target color
        RenderSettings.fogColor = targetColor;
    }
}
