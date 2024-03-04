using UnityEngine;

public class DeathPointController : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0.32f, 1f, -2.49f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnPlayer(other.gameObject);
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        CharacterController characterController = player.GetComponent<CharacterController>();
        if (characterController != null)
        {
            // Move the player to the respawn position
            characterController.enabled = false; // Disable to move without collision
            player.transform.position = respawnPosition;
            characterController.enabled = true; // Reactivate the CharacterController

            Debug.Log("Player respawned at " + respawnPosition);
        }
        else
        {
            Debug.LogWarning("CharacterController not found on the player object.");
        }
    }
}