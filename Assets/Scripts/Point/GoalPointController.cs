using UnityEngine;

public class GoalPointController_Final : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private bool m_HasBeenTriggered = false; // This variable allows me to keep track of the object's state
    public Material triggeredMaterial;

    private Material m_OriginalMaterial;
    public LevelManager levelManager;

    private void Start()
    {
        // Save the object's original material
        m_OriginalMaterial = GetComponent<Renderer>().material;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!m_HasBeenTriggered && other.gameObject.tag == PLAYER_TAG)
        {
            ScoreManager.Instance.AddScore();

            m_HasBeenTriggered = true;

            // Change object material to triggered material
            GetComponent<Renderer>().material = triggeredMaterial;
        }
    }

    private void ResetMaterial()
    {
        // Restore object's original material
        GetComponent<Renderer>().material = m_OriginalMaterial;
    }
}