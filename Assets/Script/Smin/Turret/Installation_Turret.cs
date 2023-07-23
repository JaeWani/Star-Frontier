using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installation_Turret : MonoBehaviour
{
    [SerializeField] List<Turret_Pos> pos = new List<Turret_Pos>();
    [SerializeField] GameObject arrow;
    [SerializeField] List<Turret_Base> turretPrefab = new List<Turret_Base>();
    [SerializeField] GameObject turret_prop;
    [SerializeField] GameObject effect;
    public int turretIndex;

    bool isChoice;
    bool isChange;
    [SerializeField] int curIndex;
    int maxLevel = 2;
    int Count;

    public void Init(int index)
    {
        isChoice = true;
        isChange = false;
        turretIndex = index;
        Player.Instance.transform.position = new Vector3(0, 0);
        arrow.SetActive(true);
        curIndex = 0;
        while (true)
        {
            Count++;
            if (Count > 100)
            {
                Debug.Log("Init");
                return;
            }

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
        arrow.transform.position = pos[curIndex].transform.position;
    }

    private void Update()
    {
        arrow.SetActive(isChoice);
        if (!isChoice) return;

        if (Input.GetKeyDown(KeyCode.A) && !isChange) StartCoroutine(Left());
        if (Input.GetKeyDown(KeyCode.D) && !isChange) StartCoroutine(Right());
        if (Input.GetKeyDown(KeyCode.Space) && !isChange) Choice();
    }

    public void Choice()
    {
        isChange = true;
        Instantiate(effect, pos[curIndex].transform.position, Quaternion.identity);
        if (pos[curIndex].curTurret == null)
        {
            Instantiate(turret_prop, pos[curIndex].transform.position + new Vector3(0, 0.15f), Quaternion.identity);
            var temp = Instantiate(turretPrefab[turretIndex], pos[curIndex].transform.position + new Vector3(0, 0.45f), Quaternion.identity);
            pos[curIndex].curTurret = temp;
            pos[curIndex].curTurretIndex = turretIndex;
            SoundManager.Instance.SoundInt(6, 1f, 1);
        }
        else if (pos[curIndex].level != maxLevel)
        {
            pos[curIndex].level++;
            pos[curIndex].Init(pos[curIndex].level);
        }
        SoundManager.Instance.SoundInt(5, 0.5f, 0.9f);
        arrow.SetActive(false);
        if (GameTurnManager.instance.isBreakTime)
        {
            Player.Instance.transform.position = new Vector3(0, -4);
            Player.Instance.isNotActive = false;
        }
        isChoice = false;
        isChange = false;
    }

    public IEnumerator Left()
    {
        isChange = true;
        curIndex--;
        while (true)
        {
            Count++;
            if (Count > 100)
            {
                Debug.Log("left");
                yield break;
            }
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
        yield return StartCoroutine(MoveTo(pos[curIndex].transform.position, 0.1f));
        isChange = false;
    }

    public IEnumerator Right()
    {
        isChange = true;
        curIndex++;
        while (true)
        {
            Count++;
            if (Count > 100)
            {
                Debug.Log("left");
                yield break;
            }
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
        yield return StartCoroutine(MoveTo(pos[curIndex].transform.position, 0.1f));
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
