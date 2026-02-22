using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 2f;

    private float timer;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        if (objectsToSpawn.Length == 0 || spawnPoints.Length == 0)
            return;

        int randomObject = Random.Range(0, objectsToSpawn.Length);
        int randomPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(objectsToSpawn[randomObject],
                    spawnPoints[randomPoint].position,
                    spawnPoints[randomPoint].rotation);
        audioManager.PlaySFX(audioManager.spawn);
    }
}
