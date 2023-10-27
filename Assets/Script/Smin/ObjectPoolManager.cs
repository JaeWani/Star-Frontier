using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectInfo
{
    public string objectName;
    public int objectInitialCount;
    public Transform objectParent;
    public GameObject objectPrefab;
    public Queue<GameObject> objectPool;
}
public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public List<ObjectInfo> objectInfos = new List<ObjectInfo>();

    public Dictionary<string, Queue<GameObject>> poolObject = new Dictionary<string, Queue<GameObject>>();
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        Init();
    }

    private void Init()
    {
        foreach (var item in objectInfos) // objectInfos List의 요소 갯수 만큼 반복
        {
            item.objectPool = new Queue<GameObject>(); // 새로운 Queue 생성
            poolObject.Add(item.objectName, item.objectPool); // 생성한 Queue와 오브젝트의 이름을 poolObject에 등록

            var objectParent = new GameObject(); // 오브젝트 풀러의 부모가 될 오브젝트 생성
            objectParent.name = item.objectName;
            objectParent.transform.SetParent(this.transform); // 부모 오브젝트의 위치를 이 오브젝트의 하위로 설정
            item.objectParent = objectParent.transform; // 초기화

            for (int i = 0; i < item.objectInitialCount; i++) // 오브젝트 초기 생성 갯수 만큼 반복
            {
                var obj = Instantiate(item.objectPrefab, item.objectParent); // 생성 후 부모 지정
                item.objectPool.Enqueue(obj); // Queue에 삽입
                obj.SetActive(false); // 오브젝트 비활성화
            }
        }
    }
    private void _CreatNewObject(string key, Queue<GameObject> queue)
    {
        if (queue.Count <= 0)
        {
            Debug.Log("Creat");
            Transform parent = null;
            GameObject prefab = null;
            foreach (var item in objectInfos)
            {
                if (item.objectName == key)
                {
                    parent = item.objectParent;
                    prefab = item.objectPrefab;
                }
            }

            var obj = Instantiate(prefab, parent);
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }

    private GameObject _SpawnFromPool(string key, Vector2 position)
    {
        var poolQueue = poolObject[key];
        _CreatNewObject(key, poolQueue);

        var obj = poolQueue.Dequeue();

        obj.transform.position = position;
        obj.transform.rotation = Quaternion.identity;
        obj.transform.SetParent(null);

        obj.SetActive(true);

        return obj;
    }
    private GameObject _SpawnFromPool(string key, Vector2 position, Transform parent)
    {
        var poolQueue = poolObject[key];
        _CreatNewObject(key, poolQueue);

        var obj = poolQueue.Dequeue();

        obj.transform.position = position;
        obj.transform.rotation = Quaternion.identity;
        obj.transform.SetParent(parent);

        obj.SetActive(true);

        return obj;
    }
    private GameObject _SpawnFromPool(string key, Vector2 position, Quaternion quaternion)
    {
        var poolQueue = poolObject[key];
        _CreatNewObject(key, poolQueue);

        var obj = poolQueue.Dequeue();

        obj.transform.position = position;
        obj.transform.rotation = quaternion;

        obj.SetActive(true);

        return obj;
    }
    private GameObject _SpawnFromPool(string key, Vector2 position, Transform parent, Quaternion quaternion)
    {
        var poolQueue = poolObject[key];
        _CreatNewObject(key, poolQueue);

        var obj = poolQueue.Dequeue();

        obj.transform.position = position;
        obj.transform.rotation = quaternion;
        obj.transform.SetParent(parent);

        obj.SetActive(true);

        return obj;
    }
    public static GameObject SpawnFromPool(string key, Vector2 position) { return instance._SpawnFromPool(key, position); }
    public static GameObject SpawnFromPool(string key, Vector2 position, Transform parent) { return instance._SpawnFromPool(key, position, parent); }
    public static GameObject SpawnFromPool(string key, Vector2 position, Quaternion quaternion) { return instance._SpawnFromPool(key, position, quaternion); }
    public static GameObject SpawnFromPool(string key, Vector2 position, Transform parent, Quaternion quaternion) { return instance._SpawnFromPool(key, position, parent, quaternion); }

    private void _ReturnToPool(string key, GameObject obj)
    {
        Transform parent = null;
        Queue<GameObject> pool = null;
        foreach (var item in objectInfos)
        {
            if (item.objectName == key)
            {
                parent = item.objectParent;
                pool = item.objectPool;
            }
        }

        if (parent == null)
            Debug.LogError(key + "의 이름을 가진 오브젝트는 Pooler 안에 존재하지 않습니다!");
        else
        {
            pool.Enqueue(obj);
            obj.transform.parent = parent;
        }
        obj.SetActive(false);
    }
    private IEnumerator _ReturnToPool(string key, GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        _ReturnToPool(key, obj);
    }
    public static void ReturnToPool(string key, GameObject obj) => instance._ReturnToPool(key, obj);
    public static void ReturnToPool(string key, GameObject obj, float time) => instance.StartCoroutine(instance._ReturnToPool(key, obj, time));
}
