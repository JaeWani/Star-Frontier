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
    public int damage;
    public int damageLv;
    [SerializeField] protected float checkRadius;
    public float fire_delay;
    public int speedLv;

    protected float cur_delay;
    protected Vector3 direction;

    public bool isUpgrade;
    public int upgradePrice;

    public float increase;

    public void Init(int _damage, float _checkRadius, float _fire_delay)
    {
        damage += _damage;
        checkRadius += _checkRadius;
        fire_delay -= _fire_delay;
    }
}
