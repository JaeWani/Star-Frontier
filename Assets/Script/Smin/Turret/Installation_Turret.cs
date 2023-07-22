using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installation_Turret : MonoBehaviour
{
    [SerializeField] List<Turret_Pos> pos = new List<Turret_Pos>();
    [SerializeField] GameObject shadow_ui;
    [SerializeField] GameObject arrow;
    public Turret_Base curTurret;
    bool isChoice;
    [SerializeField] int curIndex;
    int maxLevel = 1;

    void Init()
    {
        isChoice = true;
        curIndex = 0;
        while (true)
        {
            if (curIndex < 0)
            {
                curIndex = pos.Count - 1;
                continue;
            }
            if ((pos[curIndex].curTurret != curTurret && pos[curIndex].curTurret != null) || pos[curIndex].level == maxLevel)
            {
                curIndex--;
                continue;
            }
            break;
        }
        shadow_ui.SetActive(true);


    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.LeftArrow)) StartCoroutine(Left());
        if(Input.GetKeyDown(KeyCode.RightArrow)) StartCoroutine(Right());
        if(Input.GetKeyDown(KeyCode.Space)) Choice();
    }

    public void Choice()
    {
        if(pos[curIndex].curTurret == null) {
            var temp = Instantiate(curTurret, pos[curIndex].transform.position, Quaternion.identity);
            pos[curIndex].curTurret = temp;
        }else if(pos[curIndex].level != maxLevel){
            pos[curIndex].level++;
            pos[curIndex].Init(pos[curIndex].level);
        }
        shadow_ui.SetActive(false);
        isChoice = false;
    }

    public IEnumerator Left()
    {
        curIndex--;
        while (true)
        {
            yield return null;
            if (curIndex < 0)
            {
                curIndex = pos.Count - 1;
                continue;
            }
            if ((pos[curIndex].curTurret != curTurret && pos[curIndex].curTurret != null)|| pos[curIndex].level == maxLevel)
            {
                curIndex--;
                continue;
            }
            break;
        }
        StartCoroutine(MoveTo(pos[curIndex].transform.position, 1));
    }

    public IEnumerator Right()
    {
        curIndex++;
        while (true)
        {
            yield return null;
            if (curIndex > pos.Count - 1)
            {
                curIndex = 0;
                continue;
            }
            if ((pos[curIndex].curTurret != curTurret && pos[curIndex].curTurret != null) || pos[curIndex].level == maxLevel)
            {
                curIndex++;
                continue;
            }
            break;
        }
        StartCoroutine(MoveTo(pos[curIndex].transform.position, 1));
    }

    public IEnumerator MoveTo(Vector3 target, float sec)
    {
        float timer = 0f;
        Vector3 start = arrow.transform.localPosition;

        while (timer <= sec)
        {
            arrow.transform.localPosition = Vector3.Lerp(start, target, Easing.easeInOutQuart(timer / sec));
            timer += Time.deltaTime;

            yield return null;
        }

        yield break;
    }
}
