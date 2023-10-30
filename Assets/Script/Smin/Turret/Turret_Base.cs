using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Turret_Kind
{
    Basic,
    Boom,
    Lazer
}
public abstract class Turret_Base : MonoBehaviour
{
    public Turret_Kind turret_Kind;

    [SerializeField] protected Transform me;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected int level;
    [SerializeField] public int damage;
    [SerializeField] protected float checkRadius;
    [SerializeField] public float fire_delay;
    protected float cur_delay;
    protected Vector3 direction;

    public void Init(int _damage, float _checkRadius, float _fire_delay)
    {
        damage += _damage;
        checkRadius += _checkRadius;
        fire_delay -= _fire_delay;
    }
}
