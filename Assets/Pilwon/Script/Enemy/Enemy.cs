using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{

    public enum EnemySize
    {
        Small = 1,
        Middle,
        Big
    }
    [SerializeField] private EnemySize curSize;
    Rigidbody2D rigid;
    GameTurnManager turnMgr;

    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
        attTarget = GameObject.Find("Tower");

        turnMgr = GameTurnManager.instance;
    }

    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        Vector2 enemyDir = attTarget.transform.position - this.transform.position;
        rigid.velocity = enemyDir.normalized * moveSpeed;
        if (rigid.velocity.x > 0) GetComponent<SpriteRenderer>().flipX = true;
        else if (rigid.velocity.x < 0) GetComponent<SpriteRenderer>().flipX = false;
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.CompareTag("Tower"))
        {
            collison.collider.GetComponent<Tower>().Damage();
            DieDestroy();
        }
    }

    protected override void DieDestroy()
    {
        SoundManager.Instance.Sound(SoundManager.Instance.soundList[4], false, 1);
        var item = Instantiate(coin, transform.position, Quaternion.identity).GetComponent<Coin>();
        item.gold = DifficultyManager.instance.goldPerDifficulty[DifficultyManager.instance.indexDifficulty] * (int)curSize;
        GameManager.instance.monsterKill++;
        ObjectPoolManager.ReturnToPool(poolKey,gameObject);
    }

    [SerializeField] public string poolKey;
}
