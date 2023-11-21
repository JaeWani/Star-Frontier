using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPos = new List<GameObject>();
    public float curSpawnTime;
    public float maxSpawnTime;

    GameTurnManager turnMgr;

    void Start()
    {
        turnMgr = GameTurnManager.instance;
    }
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
        else if (turnMgr.isBreakTime == false && curSpawnTime >= maxSpawnTime)
        {
            int _enemyNum = Random.Range(0, turnMgr.wave[turnMgr.curWave].enemy.Count);  
            int _spawnPos = Random.Range(0, 6);
            var key = turnMgr.wave[turnMgr.curWave].enemy[_enemyNum].GetComponent<EnemyBase>().poolKey;
            ObjectPoolManager.SpawnFromPool(key,spawnPos[_spawnPos].transform.position);
            curSpawnTime = 0;   
        }
    }
}
