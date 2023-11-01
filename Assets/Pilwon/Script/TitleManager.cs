using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    [SerializeField] private Button PlayBtn;
    [SerializeField] private Button SettingBtn;
    [SerializeField] private Button ExitBtn;

    [SerializeField] private Button SettingExitBtn;

    [SerializeField] private Image FadeImg;

    [SerializeField] RectTransform SettingPanel;

    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    [SerializeField] private AudioSource source;

    void Start()
    {
        StartCoroutine(start());
        BGMSlider.value = 1;
        source = SoundManager.Instance.objs[0].GetComponent<AudioSource>();
    }

    void Update()
    {
        BGM();
    }
    private void BGM()
    {
        source.volume = BGMSlider.value;
    }
    private void AddBtnListener()
    {
        Debug.Log("AddBtnListener");
        PlayBtn.onClick.AddListener(() => StartCoroutine(Play()));
        SettingBtn.onClick.AddListener(() => StartCoroutine(Setting()));
        ExitBtn.onClick.AddListener(() => Application.Quit());
        SettingExitBtn.onClick.AddListener(() => StartCoroutine(SettingExit()));
    }
    private IEnumerator start()
    {
        yield return StartCoroutine(FadeOut());

        PlayBtn.GetComponent<RectTransform>().DOAnchorPosX(-350, 1).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.1f);
        SettingBtn.GetComponent<RectTransform>().DOAnchorPosX(-350, 1).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.1f);
        ExitBtn.GetComponent<RectTransform>().DOAnchorPosX(-350, 1).SetEase(Ease.OutQuad).OnComplete(() => AddBtnListener());
    }
    private IEnumerator FadeIn()
    {
        FadeImg.gameObject.SetActive(true);
        Color color = new Color(0, 0, 0, 0);
        FadeImg.color = color;
        float a = 0;
        while (a < 1)
        {
            a += Time.deltaTime;
            color.a = a;
            FadeImg.color = color;
            yield return null;
        }
    }
    private IEnumerator FadeOut()
    {
        Color color = new Color(0, 0, 0, 1);
        FadeImg.color = color;
        float a = 1;

        while (a >= 0)
        {
            a -= Time.deltaTime;
            color.a = a;
            FadeImg.color = color;
            yield return null;
        }
        FadeImg.gameObject.SetActive(false);
    }
    private IEnumerator Play()
    {
        yield return StartCoroutine(FadeIn());
        SceneManager.LoadScene(1);
    }
    private IEnumerator Setting()
    {
        PlayBtn.GetComponent<RectTransform>().DOAnchorPosX(-1000, 1).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.1f);
        SettingBtn.GetComponent<RectTransform>().DOAnchorPosX(-1000, 1).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.1f);
        ExitBtn.GetComponent<RectTransform>().DOAnchorPosX(-1000, 1).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(1);
        SettingPanel.DOAnchorPosX(-510, 1).SetEase(Ease.OutQuad);
    }
    private IEnumerator SettingExit()
    {
        SettingPanel.DOAnchorPosX(-1500, 1).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(1);
        PlayBtn.GetComponent<RectTransform>().DOAnchorPosX(-350, 1).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.1f);
        SettingBtn.GetComponent<RectTransform>().DOAnchorPosX(-350, 1).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.1f);
        ExitBtn.GetComponent<RectTransform>().DOAnchorPosX(-350, 1).SetEase(Ease.OutQuad);
    }
}
