using UnityEngine;

public class CollectibleController_Final : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    public float speedIncreaseAmount = 5.0f;
    public float rotationSpeedX = 50.0f; // Vitesse de rotation autour de l'axe X
    public float rotationSpeedY = 50.0f; // Vitesse de rotation autour de l'axe Y

    // public AudioClip collectSound; // Le clip audio à jouer

    // private AudioSource collectibleAudio;

    // Audio
    // [SerializeField] public AudioSource collectionSound;

    // private void Start()
    // {
    //     // Attribuez le composant AudioSource
    //     collectibleAudio = GetComponent<AudioSource>();
    //     // Attribuez le clip audio au composant AudioSource
    //     collectibleAudio.clip = collectSound;
    // }

    private void Update()
    {
        // Faire tourner les objets autour des axes X et Y
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