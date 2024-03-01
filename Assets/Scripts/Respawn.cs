using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;

    private CharacterController m_Character;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController component attached to this GameObject
        m_Character = GetComponent<CharacterController>();
        if (m_Character == null)
        {
            Debug.LogWarning("CharacterController component not found on the GameObject.");
        }
    }

    // Called once per frame
    void Update()
    {
        // Check if the CharacterController is not null and if the object's position is below the threshold
        if (m_Character != null && transform.position.y < threshold)
        {
            m_Character.Move(new Vector3(0.32f, 1f, -2.49f) - transform.position);

            Debug.Log("Respawn!");
        }   
    }
}
