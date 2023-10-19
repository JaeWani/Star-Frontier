using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Tooltip("플레이어 돈(Int)")]
    [SerializeField] Text goldText;

    public GameObject moneyUi;
    public GameObject timeUi;

    [SerializeField] GameObject winObj;
    [SerializeField] GameObject dieObj;
    [SerializeField] GameObject home;

    [Header(" # Button Obj ")]
    public GameObject skipBtn;
    public GameObject ReStartbtn;
    public GameObject MainMenuBtn;

    [Header(" # Button Ui ")]
    [SerializeField] private Button ReStartbtnU;
    [SerializeField] private Button MainMenubtnU;

    [Header(" # Include")]
    public GameObject PlayerObject;

    public int playerMoney = 100;
    public int monsterKill = 0;
    public int waveNumber = 0;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MainMenubtnU.onClick.AddListener(() => Home());
        ReStartbtnU.onClick.AddListener(() => ReStart());

        SoundManager.Instance.Sound(SoundManager.Instance.mList[0], true, 1);
    }

    public void End(bool isDie)
    {
        Time.timeScale = 0;
        if (isDie)
        {
            dieObj.SetActive(true);
        }
        else
        {
            moneyUi.SetActive(false);
            timeUi.SetActive(false);
            skipBtn.SetActive(false);

            ReStartbtn.SetActive(true);
            MainMenuBtn.SetActive(true);

            winObj.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void Home()
    {
        ReStartbtn.SetActive(false);
        MainMenuBtn.SetActive(false);
        GameTurnManager.instance.isEnd = false;

        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }

    public void ReStart()
    {
        ReStartbtn.SetActive(false);
        MainMenuBtn.SetActive(false);
        GameTurnManager.instance.isEnd = false;

        Time.timeScale = 1;
        SceneManager.LoadScene("InGame");
    }

    private void Update()
    {
        goldText.text = new string(playerMoney + "");
    }

    /// <summary>
    ///  골드 추가해주는 함수임
    /// </summary>
    public static void AddGold(int gold) => instance._AddGold(gold);
    private void _AddGold(int gold) => playerMoney += gold;

}
