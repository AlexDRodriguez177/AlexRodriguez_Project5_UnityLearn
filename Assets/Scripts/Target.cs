using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private int minStrength = 12;
    private int maxStrength = 16;
    private int torqueRange = 10;
    private float spawnXRange = 4f;
    private float spawnYPosition = -2f;

    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;

    private AudioSource objectDestroyed;
    public AudioClip objectDestroyedSound;


    /// <summary>
    /// Got the Rigidbody component and apply an upward force and random torque.
    /// Set a random position within specified ranges.
    /// </summary>
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        objectDestroyed = GameObject.Find("Border").GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            // Play the object destroyed sound effect
            objectDestroyed.PlayOneShot(objectDestroyedSound);
            // Instantiate explosion particle effect at the target's position and rotation
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            // Add score to the game manager
            gameManager.UpdateScore(pointValue);
            // Destroy the target object when clicked
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy the target object if it falls below a certain position
        Destroy(gameObject);
        // If the good objects falls below a certain position calls the game over method in GameManager
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }


    /// <summary>
    /// Calculates a random force and multiplys it by s Vector3.up 
    /// </summary>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minStrength, maxStrength);
    }
    /// <summary>
    /// Calculates a randome torque for the objects
    /// </summary>
    private float RandomTorque()
    {
        return Random.Range(-torqueRange, torqueRange);
    }
    /// <summary>
    /// Calculates a random spawn position for the target objects
    /// </summary>
    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnXRange, spawnXRange), spawnYPosition);
    }
}
