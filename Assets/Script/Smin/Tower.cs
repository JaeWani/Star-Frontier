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
        if(hp <= 0){
            GameManager.instance.moneyUi.SetActive(false);
            GameManager.instance.timeUi.SetActive(false);
            GameManager.instance.skipBtn.SetActive(false);

            GameManager.instance.ReStartbtn.SetActive(true);
            GameManager.instance.MainMenuBtn.SetActive(true);

            GameManager.instance.End(true);
        }
    }

    IEnumerator alpha(Image image, int sec)
    {
        float timer = 0f;
        while (timer <= sec)
        {
            if(hp <= 0)
            {
                damage_ui.color = new Color(1, 1, 1, 1);
            }
            image.color = new Color(1, 1, 1, 1 - timer / sec);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
