using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installation_Turret : MonoBehaviour
{
    [SerializeField] List<Turret_Pos> pos = new List<Turret_Pos>();
    [SerializeField] GameObject arrow;
    [SerializeField] List<Turret_Base> turretPrefab = new List<Turret_Base>();
    [SerializeField] GameObject turret_prop;
    public int turretIndex;

    bool isChoice;
    bool isChange;
    [SerializeField] int curIndex;
    int maxLevel = 1;

    public void Init(int index)
    {
        isChoice = true;
        isChange = false;
        turretIndex = index;
        arrow.SetActive(true);
        curIndex = 0;
        while (true)
        {
            if (curIndex < 0)
            {
                curIndex = pos.Count - 1;
                continue;
            }
            if ((pos[curIndex].curTurretIndex != turretIndex && pos[curIndex].curTurret != null) || pos[curIndex].level == maxLevel)
            {
                curIndex--;
                continue;
            }
            break;
        }
        StartCoroutine(MoveTo(pos[curIndex].transform.position, 1));
    }

    private void Update() {
        if(!isChoice) return;

        if(Input.GetKeyDown(KeyCode.LeftArrow) && !isChange) StartCoroutine(Left());
        if(Input.GetKeyDown(KeyCode.RightArrow) && !isChange) StartCoroutine(Right());
        if(Input.GetKeyDown(KeyCode.Space) && !isChange) Choice();
    }

    public void Choice()
    {
        isChange = true;
        if(pos[curIndex].curTurret == null) {
            Instantiate(turret_prop, pos[curIndex].transform.position + new Vector3(0, 0.15f), Quaternion.identity);
            var temp = Instantiate(turretPrefab[turretIndex], pos[curIndex].transform.position + new Vector3(0, 0.45f), Quaternion.identity);
            pos[curIndex].curTurret = temp;
            pos[curIndex].curTurretIndex = turretIndex;
        }else if(pos[curIndex].level != maxLevel){
            pos[curIndex].level++;
            pos[curIndex].Init(pos[curIndex].level);
        }
        arrow.SetActive(false);
        Player.Instance.isNotActive = false;
        isChoice = false;
        isChange = false;
    }

    public IEnumerator Left()
    {
        isChange = true;
        curIndex--;
        while (true)
        {
            yield return null;
            if (curIndex < 0)
            {
                curIndex = pos.Count - 1;
                continue;
            }
            if ((pos[curIndex].curTurretIndex != turretIndex && pos[curIndex].curTurret != null) || pos[curIndex].level == maxLevel)
            {
                curIndex--;
                continue;
            }
            break;
        }
        yield return StartCoroutine(MoveTo(pos[curIndex].transform.position, 0.5f));
        isChange = false;
    }

    public IEnumerator Right()
    {
        isChange = true;
        curIndex++;
        while (true)
        {
            yield return null;
            if (curIndex > pos.Count - 1)
            {
                curIndex = 0;
                continue;
            }
            if ((pos[curIndex].curTurretIndex != turretIndex && pos[curIndex].curTurret != null) || pos[curIndex].level == maxLevel)
            {
                curIndex++;
                continue;
            }
            break;
        }
        yield return StartCoroutine(MoveTo(pos[curIndex].transform.position, 0.5f));
        isChange = false;
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
