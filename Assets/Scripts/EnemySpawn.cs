using System.Numerics;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minSpawnTime = 1.0f;
    [SerializeField] float maxSpawnTime = 1.0f;    

    float spawnDistance = 10f;
    UnityEngine.Vector2 screenBounds;
    UnityEngine.Vector2 spawnPos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime,maxSpawnTime);
        screenBounds=Camera.main.ScreenToWorldPoint(new UnityEngine.Vector2(Screen.width,Screen.height));

        int side = Random.Range(0,4);
        switch (side)
        {
            case 0:
                spawnPos = new UnityEngine.Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDistance);
                break;
            case 1:
                spawnPos = new UnityEngine.Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnDistance);
                break;
            case 2:
                spawnPos = new UnityEngine.Vector2(-screenBounds.x - spawnDistance,Random.Range(-screenBounds.y, screenBounds.y));
                break;
            case 3:
                spawnPos = new UnityEngine.Vector2(-screenBounds.x - spawnDistance,Random.Range(-screenBounds.y, screenBounds.y));
                break;
        }
        Instantiate(enemyPrefab, spawnPos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);
    }
}
