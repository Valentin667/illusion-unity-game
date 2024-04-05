using UnityEngine;

public class DeathPointController : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0.32f, 1f, -2.49f);

    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            RespawnPlayer(other.gameObject);
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        CharacterController characterController = player.GetComponent<CharacterController>();
        if (characterController != null)
        {
            // Move player to respawn position
            characterController.enabled = false; // Disable to move without collision
            player.transform.position = respawnPosition;
            characterController.enabled = true; // Reactivate the CharacterController
        }
    }
}