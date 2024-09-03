using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2();
        float randomValue = Random.value;

        if (randomValue < 0.25f)
            spawnPosition = new Vector2(Random.Range(-10f, 10f), 10f);
        else if (randomValue < 0.5f)
            spawnPosition = new Vector2(Random.Range(-10f, 10f), -10f);
        else if (randomValue < 0.75f)
            spawnPosition = new Vector2(10f, Random.Range(-10f, 10f));
        else
            spawnPosition = new Vector2(-10f, Random.Range(-10f, 10f));

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
