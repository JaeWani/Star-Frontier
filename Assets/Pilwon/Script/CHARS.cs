using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHARS : MonoBehaviour
{
    [SerializeField] private GameObject posTarget;
    [SerializeField] private float moveSpeed;


    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        Vector2.MoveTowards(transform.position, posTarget.transform.position, moveSpeed * Time.deltaTime );
    }
}
