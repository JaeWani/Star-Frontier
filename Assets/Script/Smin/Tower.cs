using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] Image damage_ui;

    public void Damage(){
        hp--;
        StartCoroutine(alpha(damage_ui, 1));
        if(hp >= 0){
            GameManager.instance.End(true);
        }
    }

    IEnumerator alpha(Image image, int sec)
    {
        float timer = 0f;
        while (timer <= sec)
        {
            image.color = new Color(1, 1, 1, 1 - timer / sec);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
