using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    bool damage = true;
    void Start()
    {
        SoundManager.Instance.SoundInt(7, 1f, Random.Range(-0.4f, 1.2f));
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!damage)
            return;
        if (other.TryGetComponent<EnemyBase>(out var e_hit))
        {
            e_hit.Damage(10);
        }
    }
}
