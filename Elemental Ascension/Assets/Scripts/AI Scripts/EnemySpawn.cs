using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public float spawnRate = 5.0f;
    public float spawnRadius = 5.0f;
    public int poolSize = 2;
    public int maxEnemies = 3;
    private List<GameObject> enemyPool = new List<GameObject>();
    private float spawnTimer = 0f;
    private int enemiesSpawned = 0;
    void Start()
    {
        // pooling
        for (int i = 0; i < poolSize; i++)
        {
            foreach (var enemyPrefab in enemyPrefabs)
            {
                GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
                enemy.SetActive(false);
                enemyPool.Add(enemy);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesSpawned >= maxEnemies)
        {
            // stops spawning if player killed enough enemies
            return;
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }
    void SpawnEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.transform.position = transform.position + Random.insideUnitSphere * spawnRadius;
                enemy.SetActive(true);
                enemiesSpawned++;
                return;
            }
        }
    }
}
