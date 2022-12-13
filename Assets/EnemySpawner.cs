using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] float timeToSpawn = 1f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeToSpawn;
        SpawnEnemy();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = timeToSpawn;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, transform);
    }

}
