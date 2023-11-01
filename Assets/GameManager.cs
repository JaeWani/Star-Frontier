using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Canvas FloatingCanvas;

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
    [SerializeField] private Button ReStartbtn2;
    [SerializeField] private Button MainMenubtn2;



    [Header(" # Include")]
    public GameObject PlayerObject;

    public int playerMoney = 100;
    public int monsterKill = 0;
    public int waveNumber = 0;
    [Header(" # GameOver")]
    public RectTransform GameOverPanel;
    public RectTransform GameOverImage;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ReStartbtn2.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        });
        MainMenubtn2.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        });

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
    public void GameOver()
    {
        GameTurnManager.instance.isPause = true;
        Time.timeScale = 0;
        StartCoroutine(over());
        IEnumerator over()
        {
            GameOverPanel.DOAnchorPosY(0, 1f).SetEase(Ease.OutQuad).SetUpdate(true);
            GameOverImage.DOAnchorPosY(250f, 1.2f).SetEase(Ease.OutQuad).SetUpdate(true);
            ReStartbtn2.GetComponent<RectTransform>().DOAnchorPosY(-100f, 1.5f).SetEase(Ease.OutQuad).SetUpdate(true);
            MainMenubtn2.GetComponent<RectTransform>().DOAnchorPosY(-100f, 1.5f).SetEase(Ease.OutQuad).SetUpdate(true);
            yield return null;
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
