using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance{get; private set;}

    [Tooltip("플레이어 돈(Int)")]
    [SerializeField] Text goldText;
    [SerializeField] GameObject winObj;
    [SerializeField] GameObject dieObj;
    [SerializeField] GameObject home;
    public int playerMoney = 100;

    void Awake()
    {
        instance = this;
    }

    private void Start() {
        SoundManager.Instance.Sound(SoundManager.Instance.mList[0], true, 1);
    }

    public void End(bool isDie){
        Time.timeScale = 0;
        if(isDie) dieObj.SetActive(true);
        else winObj.SetActive(true);
        winObj.SetActive(true);
    }

    public void Home(){
        SceneManager.LoadScene("Title");
    }

    private void Update() {
        goldText.text = new string(playerMoney + "");
    }
}
