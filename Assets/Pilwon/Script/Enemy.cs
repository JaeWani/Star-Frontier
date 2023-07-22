using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyInfo
{
    // 적의 공통점 : 체력, 움직임속도, 공격력, 공격딜레이, 공격타겟
    [Header("# Enemy Info")]
    public GameObject attTarget;
    public int hp;
    public int moveSpeed;
    public int att;
    [SerializeField] private float enemyAttDelay;
}

public class Enemy : MonoBehaviour
{
    public EnemyInfo enemy;

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemy.attTarget = GameObject.Find("Tower");
    }

    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        Vector2 enemyDir = enemy.attTarget.transform.position - this.transform.position;
        rigid.velocity = enemyDir.normalized * enemy.moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if(collison.gameObject.CompareTag("Tower"))
        {
            Destroy(gameObject);
        }
    }
}
