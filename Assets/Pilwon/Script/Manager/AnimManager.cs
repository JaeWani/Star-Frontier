using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    [Header("# Title Inspector")]
    [SerializeField] private GameObject[] B_Titles;
    [SerializeField] private GameObject B_Title;
    [SerializeField] private GameObject S_Title;
    [SerializeField] private GameObject[] Buttons;


    [SerializeField] private GameObject chars;

    [Header("# Target Pos")]
    [SerializeField] private GameObject titleToPos;
    [SerializeField] private GameObject s_titleToPos;
    [SerializeField] private GameObject charsToPos;
    [SerializeField] private GameObject[] ButtonsToPos;


    void Start()
    {
        StartCoroutine(TitleAnim());
    }

    IEnumerator TitleAnim()
    {
        for (int i = 0; i < 4; i++)
        {
            B_Titles[i].SetActive(true);

            yield return StartCoroutine(MoveTo(B_Titles[i].transform, new Vector3(1.4f, 1.4f), 0.3f));
            yield return new WaitForSeconds(0.1f);
            yield return StartCoroutine(MoveTo(B_Titles[i].transform, new Vector3(1f, 1f), 0.3f));
        }

        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(MoveTo_2(S_Title, s_titleToPos.transform.position, 1));
        yield return new WaitForSeconds(0.25f);
        S_Title.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(MoveTo_2(chars, charsToPos.transform.position, 2));
        yield return StartCoroutine(MoveTo_2(B_Title, titleToPos.transform.position, 1.5f));

        // Button
        for (int i = 0; i < 3; i++)
        {
            yield return StartCoroutine(MoveTo_2(Buttons[i], ButtonsToPos[i].transform.position, 2));
            yield return new WaitForSeconds(0.03f);
        }
    }

    IEnumerator MoveTo(Transform obj, Vector3 target, float sec)
    {
        float timer = 0f;
        Vector3 start = obj.localScale;

        while (timer <= sec)
        {
            obj.localScale = Vector2.Lerp(start, target, timer / sec);
            timer += Time.deltaTime;
            yield return null;
        }

        yield break;
    }

    IEnumerator MoveTo_2(GameObject a, Vector3 toPos, float speed)
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
