using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private int minStrength = 12;
    private int maxStrength = 16;
    private int torqueRange = 10;
    private float spawnXRange = 4f;
    private float spawnYPosition = -6f;

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
    }


    void Update()
    {

    }
    /// <summary>
    /// Calculates a random force and multiplys it by s Vector3.up 
    /// </summary>
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minStrength, maxStrength);
    }
    /// <summary>
    /// Calculates a randome torque for the objects
    /// </summary>
    float RandomTorque()
    {
        return Random.Range(-torqueRange, torqueRange);
    }
    /// <summary>
    /// Calculates a random spawn position for the target objects
    /// </summary>
    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnXRange, spawnXRange), -spawnYPosition);
    }
}
