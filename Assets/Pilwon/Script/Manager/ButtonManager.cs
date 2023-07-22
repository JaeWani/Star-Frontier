using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private Button startBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button settingQuitBtn;
    [SerializeField] private Button quitBtn;

    [Header("Setting Btn")]
    [SerializeField] private GameObject settingUi;
    [SerializeField] private GameObject targetPos;
    [SerializeField] private GameObject targetPos2;
    [SerializeField] private GameObject[] Objects;

    void Start()
    {
        startBtn.onClick.AddListener(() => StartBtn());
        settingBtn.onClick.AddListener(() => SettingBtn());
        settingQuitBtn.onClick.AddListener(() => StartCoroutine(SettingQuitBtn()));
        quitBtn.onClick.AddListener(() => QuitBtn());


    }

    private void StartBtn()
    {
        SceneManager.LoadScene("InGame");
    }

    private void SettingBtn()
    {
        for (int i = 0; i < 3; i++)
        {
            Objects[i].SetActive(false);
        }
        StartCoroutine(MoveTo(settingUi, targetPos.transform.position, 1.5f));
        Debug.Log("설정창");
    }

    IEnumerator SettingQuitBtn()
    {
        StartCoroutine(MoveTo(settingUi, targetPos2.transform.position, 1.5f));
        yield return new WaitForSeconds(0.6f);
        for (int i = 0; i < 3; i++)
        {
            Objects[i].SetActive(true);
        }

    }

    private void QuitBtn()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }

    IEnumerator MoveTo(GameObject a, Vector3 toPos, float speed)
    {
        float count = 0;
        Vector3 wasPos = a.transform.position;

        while (true)
        {
            count += Time.deltaTime * speed;
            a.transform.position = Vector3.Lerp(wasPos, toPos, count);

            if (count >= 1)
            {
                a.transform.position = toPos;
                break;
            }
            yield return null;
        }
    }
}
