using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float GRAVITY_VALUE = -19.81f;    
    
    [SerializeField] private float m_BaseSpeed = 5.0f;
    [SerializeField] private float m_JumpHeight = 1.0f; 
    [SerializeField] private float m_TurnSmoothTime = 0.1f; 

    private CharacterController m_Character;    
    private float m_JumpVelocity;   
    private float m_TurnSmoothVelocity; 

    private Vector2 m_MoveVector;   
    private float m_CurrentSpeed;

    #region Initialization  
    private void OnEnable()
    {
        m_Character = gameObject.AddComponent<CharacterController>();   
        m_Character.radius = 0.4f;  
        m_CurrentSpeed = m_BaseSpeed;
    }

    private void OnDisable()
    {
        Destroy(m_Character);   
    }
    #endregion

    private void FixedUpdate()  
    {
        Move(); 

        ApplyGravity(); 
    }

    public void ReadMoveInput(InputAction.CallbackContext context)  
    {
        m_MoveVector = context.ReadValue<Vector2>();    
    }   

    private void Move() 
    {
        // Find the direction
        Vector3 direction = new Vector3(m_MoveVector.x, 0f, m_MoveVector.y);    

        if (direction.magnitude >= 0.1f)    
        {
            // Get direction angle from direction vector
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;  

            // Add camera rotation to move based on camera forward
            targetAngle += Camera.main.transform.eulerAngles.y; 

            // Smooth the angle over time to avoid snappy rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_TurnSmoothVelocity, m_TurnSmoothTime);  

            // Apply smoothed rotation
            transform.rotation = Quaternion.Euler(0f, angle, 0f);   

            // Convert direction angle into a moving vector
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;  

            // Apply movement
            m_Character.Move(moveDir.normalized * m_CurrentSpeed * Time.deltaTime);    
        }
    }

    private void ApplyGravity() 
    {
        // Reset gravity value and return early if grounded
        if (m_Character.isGrounded && m_JumpVelocity < 0)   
        {
            m_JumpVelocity = 0f;    
            return; 
        }

        // Otherwise increment velocity with gravity
        m_JumpVelocity += GRAVITY_VALUE * Time.deltaTime;   

        // Apply velocity
        m_Character.Move(Vector3.up * m_JumpVelocity * Time.deltaTime); 
    }

    public void Jump()  
    {
        // Can't jump in the air
        if (!m_Character.isGrounded)    
        {
            return; 
        }

        // Apply jump to the current velocity
        m_JumpVelocity += Mathf.Sqrt(m_JumpHeight * -GRAVITY_VALUE);
        
        m_Character.Move(Vector3.up * m_JumpHeight * Time.deltaTime);    
    }

    public void AdjustSpeed(float speedModifier)
    {
        // Modifier la vitesse actuelle
        m_CurrentSpeed += speedModifier;

        // Assurez-vous que la vitesse ne devient pas négative
        m_CurrentSpeed = Mathf.Max(0f, m_CurrentSpeed);
    }
}