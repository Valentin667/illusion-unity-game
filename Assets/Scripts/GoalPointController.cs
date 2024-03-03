using UnityEngine;

public class GoalPointController_Final : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private bool hasBeenTriggered = false; // Cette variable me permet de garder une trace de l'état de l'objet
    public Material triggeredMaterial; // Matériau à appliquer une fois que mon objet est déclenché

    private Material originalMaterial; // Matériau d'origine de mon objet
    public LevelManager levelManager;

    private void Start()
    {
        // Enregistrez le matériau d'origine de l'objet
        originalMaterial = GetComponent<Renderer>().material;
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && other.gameObject.tag == PLAYER_TAG)
        {
            ScoreManager.Instance.AddScore();

            hasBeenTriggered = true;

            // Changer le matériau de l'objet pour le matériau déclenché
            GetComponent<Renderer>().material = triggeredMaterial;

            // if (GameObject.FindGameObjectsWithTag("GoalPoint").Length == 1)
            // {
            //     // Passez au niveau suivant
            //     levelManager.LoadNextLevel();
            // }
        }
    }

    private void ResetMaterial()
    {
        // Rétablir le matériau d'origine de l'objet
        GetComponent<Renderer>().material = originalMaterial;
    }
}