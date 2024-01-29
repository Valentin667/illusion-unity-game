using UnityEngine;

public class CollectibleController_Final : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            ScoreManager.Instance.AddScore();

            gameObject.SetActive(false);
        }
    }
}