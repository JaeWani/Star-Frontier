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
    [SerializeField] protected float hp;
    [SerializeField] protected float maxHP;
    [SerializeField] protected float moveSpeed;
    public GameObject deathEffect;
    public GameObject FloatingText;
    public Action dieAction;
    protected Animator anim;
    bool isDie;
    SpriteRenderer spr;

    private float baseMoveSpeed;
    
    private Material _material;

    private void Awake()
    {
        baseMoveSpeed = moveSpeed;
        dieAction += DieDestroy;
    }

    private void OnEnable()
    {
        isDie = false;
        spr = GetComponent<SpriteRenderer>();
        hp = maxHP * GameTurnManager.instance.enemyHealthMultiply;

        spr.color = new Color(1, 1, 1, 1);
        StopAllCoroutines();

        _material = spr.material;

        StartCoroutine(DissolveShow());
    }
    protected virtual void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public virtual void Damage(float damage)
    {
        hp -= damage;
        //var obj = ObjectPoolManager.SpawnFromPool("FloatingText",new Vector3(0,0,1) + transform.position).GetComponent<FloatingText>().str = damage.ToString("0.0");
        if (hp <= 0)
        {
            if (isDie) return;
            isDie = true;
           ObjectPoolManager.ReturnToPool("DeathEffect",ObjectPoolManager.SpawnFromPool("DeathEffect",transform.position), 2);
            dieAction?.Invoke();
            return;
        }
        
        StartCoroutine(alpha(spr, 1));
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
    
    private IEnumerator DissolveShow()
    {
        float count = 1;

        while (count > 0)
        {
            _material.SetFloat("_DissolveAmount", count);
            count -= Time.deltaTime;
            yield return null;
        }
    }

    protected abstract void DieDestroy();
}
