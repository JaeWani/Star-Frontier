using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private List<GameObject> spawnPos = new List<GameObject>();
    
    [SerializeField] private float curSpawnTime;
    [SerializeField] private float maxSpawnTime;

    void Update()
    {
        EnemySpawn();
    }

    void EnemySpawn()
    {
        if (curSpawnTime < maxSpawnTime)
        {
            curSpawnTime += Time.deltaTime;
        }

        else if (curSpawnTime >= maxSpawnTime)
        {
            int _num = Random.Range(0, 6);  
            Instantiate(enemy, spawnPos[_num].transform.position , Quaternion.identity);

            curSpawnTime = 0;   
        }
    }
}
