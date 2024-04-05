using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float threshold = -10f;
    [SerializeField] private Vector3 respawnPosition = new Vector3(0.32f, 1f, -2.49f);
    private CharacterController m_Character;

    void Start()
    {
        m_Character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (m_Character != null && transform.position.y < threshold)
        {
            m_Character.Move(respawnPosition - transform.position);
        }
    }
}
