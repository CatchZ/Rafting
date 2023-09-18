using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public List<GameObject> obstaclePrefab;
    public List<GameObject> collectablePrefab;
    private float spawnrange = 95;
    public int enemyLimit = 3;
    public int obsticalLimit = 30;
    public int collectibleLimit = 20;
    public int enemyCount;
    public int collectibleCount;
    public int obstacleCount;
    public int spawnCount = 1;
    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {
        spawnCollectable();
        spawnEnemys();
        spawnObstacle();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnrange, spawnrange);
        float spawnPosZ = Random.Range(-spawnrange, spawnrange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnPrefabWave(int enemiesToSpawn, GameObject prefab)
    {
        for (int i = 0; i < enemiesToSpawn; i++) { Instantiate(prefab, GenerateSpawnPosition(), prefab.transform.rotation); }
    }

    private void spawnEnemys()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount < enemyLimit)
        {
            SpawnPrefabWave(spawnCount, enemyPrefab[RandomListElement(enemyPrefab)]);
        }
    }
    private void spawnObstacle()
    {
        obstacleCount = FindObjectsOfType<Obstacle>().Length;
        if (obstacleCount < obsticalLimit)
        {
            SpawnPrefabWave(spawnCount, obstaclePrefab[RandomListElement(obstaclePrefab)]);
        }
    }
    private void spawnCollectable()
    {
        collectibleCount = FindObjectsOfType<Collectable>().Length;
        if (collectibleCount < collectibleLimit)
        {
            SpawnPrefabWave(spawnCount, collectablePrefab[RandomListElement(collectablePrefab)]); ;
        }
    }

    private int RandomListElement(List<GameObject> list) {
        return Random.Range(0, list.Count);
    }

}
