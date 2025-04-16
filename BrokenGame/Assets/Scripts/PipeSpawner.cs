using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1f;
    public float heightOffset = 3f;

    void Start()
    {
        InvokeRepeating("SpawnPipe", 1f, spawnRate);
    }

    void SpawnPiedPiper()
    {
        // Randomly spawn pipes at various y-coordinates, some off-screen
        float randomY = Random.Range(-5f, 5f); // This range can spawn pipes off-screen
        float randomZRotation = Random.Range(0f, 360f); // Generate a random Z rotation between 0 and 360 degrees

        // Create a Quaternion for the random rotation
        Quaternion randomRotation = Quaternion.Euler(0, 0, randomZRotation);

        // Instantiate the pipe with the random rotation
        GameObject pipe = Instantiate(pipePrefab, new Vector2(10, randomY), randomRotation);
    }
}
