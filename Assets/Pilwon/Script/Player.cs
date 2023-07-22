using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("# Player Info <<")]
    [Tooltip("움직임 속도(float)")]
    public float playerSpeed;

    [SerializeField] private GameObject coinMagent;

    // Component
    Rigidbody2D rigid;
    // Component

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float _inputX = Input.GetAxisRaw("Horizontal");
        float _inputY = Input.GetAxisRaw("Vertical");

        Vector2 _Vec = new Vector2(_inputX, _inputY).normalized;
        rigid.velocity = _Vec * playerSpeed;
    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.name.Equals("Player"))
        {
            Destroy(collison.gameObject);
            Debug.Log("돈증가");
        }
    }
}

