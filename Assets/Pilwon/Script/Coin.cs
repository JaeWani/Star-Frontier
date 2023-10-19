using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] public int gold; // 이 골드를 획득했을 때 몇 골드를 지급할 지

    [SerializeField] private float flySpeed; // 날아갈 속도

    [SerializeField] private bool isMagnet; // 플레이어에게 닿으면 코인이 갈 지 판단해주는 변수

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Magnet();
    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("CoinMagnet"))
            isMagnet = true;

        if (collison.CompareTag("Player"))
        {
            GameManager.AddGold(gold);
            Destroy(gameObject);
        }

    }
    void Magnet()
    {
        if (isMagnet)
        {
            Vector2 target = GameManager.instance.PlayerObject.transform.position;

            Vector2 direction = target - (Vector2)transform.position;

            rigid.velocity = direction * flySpeed;
        }
    }
}
