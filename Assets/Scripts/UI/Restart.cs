using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(() =>
        {
            RestartGame();
        });
    }

    // Méthode de redémarrage du jeu
    void RestartGame()
    {
        SceneManager.LoadScene(0); // Charge la première scène du jeu

        // Ou réinitialise les éléments du jeu à leur état initial
        // Exemple : ScoreManager.Instance.ResetScore();
        //           GameManager.Instance.ResetGame();
    }
}
