using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<EnemyBase>(out var e_hit))
            {
                e_hit.Damage(10);
            }
    }
}
