using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret_Base : MonoBehaviour
{
    [SerializeField] protected Transform me;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected int level;
    [SerializeField] protected int damage;
    [SerializeField] protected float checkRadius;
    [SerializeField] protected float fire_delay;
    protected float cur_delay;
    protected Vector3 direction;

    public void Init(int _damage, float _checkRadius, float _fire_delay)
    {
        damage += _damage;
        checkRadius += _checkRadius;
        fire_delay -= _fire_delay;
    }
}
