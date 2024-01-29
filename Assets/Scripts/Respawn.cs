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
        // Assuming the CharacterController is on the same GameObject as this script
        m_Character = GetComponent<CharacterController>();
        if (m_Character == null)
        {
            // Log a warning if the CharacterController component is not found
            Debug.LogWarning("CharacterController component not found on the GameObject.");
        }
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (m_Character != null && transform.position.y < threshold)
        {
            m_Character.Move(new Vector3(3f, 1f, -2.26f) - transform.position);

            Debug.Log("Respawn!");
        }   
    }
}
