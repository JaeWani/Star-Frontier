using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button quitBtn;

    void Start()
    {
        startBtn.onClick.AddListener(() => StartBtn());
        settingBtn.onClick.AddListener(() => SettingBtn());
        quitBtn.onClick.AddListener(() => QuitBtn());
    }

    private void StartBtn()
    {
        SceneManager.LoadScene("InGame");
    }

    private void SettingBtn()
    {
        Debug.Log("설정창");
    }

    private void QuitBtn()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }
}
