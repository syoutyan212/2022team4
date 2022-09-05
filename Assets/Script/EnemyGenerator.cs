using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    public bool spawnEnabled = false;

    [SerializeField]
    int maxEnemies = 10;
    [SerializeField]
    float minPositionX = -3;
    [SerializeField]
    float maxPositonX = 3;
    [SerializeField]
    float minSpawnInterval = 1;
    [SerializeField]
    float maxSpawnInterval = 3;
    [SerializeField]
    GameObject[] enemyPrefabs;

    bool spawning = false;

    void Update()
    {
        if (spawnEnabled)
        {
            StartCoroutine(SpawnTimer());
        }
    }

    IEnumerator SpawnTimer()
    {
        if (!spawning)
        {
            if (SpawnEnemy())
            {
                spawning = true;

                float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(interval);

                spawning = false;
            }
            else
            {
                yield return null;
            }
        }

        yield return null;
    }

    bool SpawnEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length >= maxEnemies)
        {
            return false;
        }
        else
        {
            int choosedIndex = Random.Range(0, enemyPrefabs.Length);
            float diffPositionX = Random.Range(minPositionX, maxPositonX);
            Vector3 position = new Vector3(transform.position.x + diffPositionX, transform.position.y, transform.position.z);
            GameObject Enemy = Instantiate(enemyPrefabs[choosedIndex], position, Quaternion.identity);
            WaypointPatrol waypointPatrol = Enemy.GetComponent<WaypointPatrol>();
            waypointPatrol.waypoints = waypoints;
            waypointPatrol.SetinitialDestination();
            return true;
        }
    }
}