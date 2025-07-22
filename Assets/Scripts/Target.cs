using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private int minStrength = 12;
    private int maxStrength = 16;
    private int torqueRange = 10;
    private float spawnXRange = 4f;
    private float spawnYPosition = -6f; 


    void Start()
    {
       targetRb = GetComponent<Rigidbody>();
       
       targetRb.AddForce(Vector3.up * Random.Range(minStrength, maxStrength), ForceMode.Impulse);
       
       targetRb.AddTorque(Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), ForceMode.Impulse);
       
       transform.position = new Vector3(Random.Range(-spawnXRange, spawnXRange), -spawnYPosition);
    }

    
    void Update()
    {
        
    }
}
