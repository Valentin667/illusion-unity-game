using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float threshold = -10f; // Définition de la valeur par défaut et ajout de l'attribut [SerializeField]
    private CharacterController m_Character;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming the CharacterController is on the same GameObject as this script
        m_Character = GetComponent<CharacterController>();
        if (m_Character == null)
        {
            // Log a warning if the CharacterController component is not found
            Debug.LogWarning("CharacterController component not found on the GameObject.");
        }
    }

    // Called once per frame
    void Update()
    {
        if (m_Character != null && transform.position.y < threshold)
        {
            m_Character.Move(new Vector3(0.32f, 1f, -2.49f) - transform.position);
            Debug.Log("Respawn!");
        }
    }
}
