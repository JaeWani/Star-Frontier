using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret_Base : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected int level;
    [SerializeField] protected float damage;
    [SerializeField] protected float checkRadius;
    [SerializeField] protected float fire_delay;
    protected float cur_delay;

    public void Init(float _damage, float _checkRadius, float _fire_delay)
    {
        damage += _damage;
        checkRadius += _checkRadius;
        fire_delay -= _fire_delay;
    }
}
