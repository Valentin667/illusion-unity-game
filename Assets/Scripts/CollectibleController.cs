using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    public float speedIncreaseAmount = 5.0f;
    public float rotationSpeedX = 50.0f; // Speed of rotation about the X axis
    public float rotationSpeedY = 50.0f; // Speed of rotation about the Y axis

    private void Update()
    {
        // Rotate objects around the X and Y axes
        transform.Rotate(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            other.gameObject.GetComponent<PlayerController>().AdjustSpeed(speedIncreaseAmount);

            // collectionSound.Play();
            
            // Jouez le son
            // collectibleAudio.Play();

            gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }
}