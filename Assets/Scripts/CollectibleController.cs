using UnityEngine;

public class CollectibleController_Final : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    public float speedIncreaseAmount = 5.0f;
    public float rotationSpeedX = 50.0f; // Vitesse de rotation autour de l'axe X
    public float rotationSpeedY = 50.0f; // Vitesse de rotation autour de l'axe Y

    private void Update()
    {
        // Faire tourner les objets autour des axes X et Y
        transform.Rotate(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            ScoreManager.Instance.AddScore();

            other.gameObject.GetComponent<PlayerController>().AdjustSpeed(speedIncreaseAmount);

            gameObject.SetActive(false);
        }
    }
}