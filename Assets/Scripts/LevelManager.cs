using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs; // Tableau des prefabs des différents niveaux
    public float fadeDuration = 1f; // Durée de la transition de fondu
    public float goalPointsForLevel1 = 1; // Nombre de GoalPoint pour le niveau 1

    private int currentLevelIndex = 0; // Index du niveau actuel
    private GameObject currentLevelInstance; // Instance du niveau actuel
    private bool isTransitioning = false; // Indique si une transition de niveau est en cours

    private void Start()
    {
        LoadLevel(currentLevelIndex);
    }

    private void Update()
    {
        // Vérifie si le score est suffisant pour passer au niveau suivant
        if (!isTransitioning && ScoreManager.Instance.Score >= goalPointsForLevel1 * (currentLevelIndex + 1))
        {
            LoadNextLevel();
        }
    }

    private void LoadLevel(int levelIndex)
    {
        // Détruire le niveau actuel s'il existe déjà
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance);
        }

        ScoreManager.Instance.ResetScore();

        ScoreManager.IncrementTotalScore();

        // Instancier le nouveau niveau
        currentLevelInstance = Instantiate(levelPrefabs[levelIndex], Vector3.zero, Quaternion.identity);
    }

    public void LoadNextLevel()
    {
        if (currentLevelIndex < levelPrefabs.Length - 1)
        {
            StartCoroutine(TransitionToNextLevel());
            currentLevelIndex++;
        }
        else
        {
            Debug.Log("Bravo, vous avez terminé le jeu");
        }
    }

    private IEnumerator TransitionToNextLevel()
    {
        isTransitioning = true;

        // Réduire l'opacité de la scène à zéro avec une transition de fondu
        yield return FadeScene();

        // Charger le prochain niveau
        LoadLevel(currentLevelIndex);

        isTransitioning = false;
    }

    private IEnumerator FadeScene()
    {
        float elapsedTime = 0f;
        Color originalColor = Color.black;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            // Mettre à jour la couleur de fond
            RenderSettings.fogColor = Color.Lerp(originalColor, targetColor, elapsedTime / fadeDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Assurez-vous que la couleur de fond est exactement la couleur cible
        RenderSettings.fogColor = targetColor;
    }
}
