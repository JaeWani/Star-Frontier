using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyBase : MonoBehaviour
{
    // 적의 공통점 : 체력, 움직임속도, 공격력, 공격딜레이, 공격타겟
    [Header("# Enemy Info")]
    [SerializeField] protected GameObject attTarget;
    [SerializeField] protected GameObject coin;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] protected float moveSpeed;
    public GameObject deathEffect;
    public Action dieAction;
    protected Animator anim;
    bool isDie;
    SpriteRenderer spr;

    private float baseMoveSpeed;

    private void Awake()
    {
        baseMoveSpeed = moveSpeed;
        dieAction += DieDestroy;
    }

    private void OnEnable()
    {
        isDie = false;
        spr = GetComponent<SpriteRenderer>();
        hp = maxHP * GameTurnManager.instance.curWave * 2;
        moveSpeed += GameTurnManager.instance.curWave / 2;

        spr.color = new Color(1, 1, 1, 1);
        StopAllCoroutines();
    }
    protected virtual void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public virtual void Damage(int damage)
    {
        hp -= damage;
        StartCoroutine(alpha(spr, 1));

        if (hp <= 0)
        {
            if (isDie) return;
            isDie = true;
            
            ObjectPoolManager.ReturnToPool("DeathEffect",ObjectPoolManager.SpawnFromPool("DeathEffect",transform.position), 2);
            dieAction?.Invoke();
        }
    }

    IEnumerator alpha(SpriteRenderer image, int sec)
    {
        float timer = 0.5f;
        while (timer <= sec)
        {
            image.color = new Color(1, 1, 1, timer / sec);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Speed UP Col"))
        {
            // Speed Up Col 에 닿으면 스피드 10% 증가
            moveSpeed += baseMoveSpeed * 0.1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Speed UP Col"))
        {
            // Speed Up Col 에서 나가면 원래 스피드로 바뀜
            moveSpeed -= baseMoveSpeed * 0.1f;
        }
    }

    protected abstract void DieDestroy();
}
