using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<EnemyBase>(out var e_hit))
            {
                e_hit.Damage(10);
            }
    }
}
