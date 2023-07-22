using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject window;

    public void Use()
    {
        Player.Instance.rigid.velocity = new Vector2(0, 0);
        window.SetActive(true);
    }
}
