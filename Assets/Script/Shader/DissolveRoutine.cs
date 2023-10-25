using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveRoutine : MonoBehaviour
{
    private Material _material;

    private void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
        
        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve()
    {
        float count = 1;

        while (count > 0)
        {
            _material.SetFloat("_DissolveAmount", count);
            count -= Time.deltaTime;
            yield return null;
        }
    }
}