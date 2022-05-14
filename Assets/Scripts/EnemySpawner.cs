using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemiesMaxValue = 3;
    public float spawnInterval = 2f;

    public Transform[] spawnPositons = new Transform[1];
    public Tank[] enemyTypes = new Tank[3];

    private GameObject[] enemies;

    void Start()
    {
        foreach (Transform position in spawnPositons)
        {
            SpawnRandomEnemy(position);
        }
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length < enemiesMaxValue)
            {
                int randomSpawnPositionIndex = Random.Range(0, spawnPositons.Length);
                SpawnRandomEnemy(spawnPositons[randomSpawnPositionIndex]);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomEnemy(Transform spawnPoint)
    {
        int randomIndex = Random.Range(0, enemyTypes.Length); 
        Instantiate(enemyTypes[randomIndex], spawnPoint.position, enemyTypes[randomIndex].transform.rotation);
    }
}
