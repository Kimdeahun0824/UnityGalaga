using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager myInstance = null;
    public static ObjectPoolManager Instance
    {
        get
        {
            if (myInstance == null)
            {
                return null;
            }
            return myInstance;
        }
    }

    private Stack<GameObject> PlayerBulletPool;
    private Stack<GameObject> EnemyBulletPool;
    public GameObject PlayerBulletPrefab;
    public GameObject EnemyBulletPrefab;
    public int PlayerBulletCount;
    public int EnemyBulletCount;

    void Awake()
    {
        if (myInstance == null)
        {
            myInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        PlayerBulletPool = new Stack<GameObject>();
        for (int i = 0; i < PlayerBulletCount; i++)
        {
            GameObject object_ = Instantiate(PlayerBulletPrefab);
            object_.transform.parent = gameObject.transform;
            object_.transform.position = Vector3.zero;
            object_.SetActive(false);
            PlayerBulletPool.Push(object_);
        }

        EnemyBulletPool = new Stack<GameObject>();
        for (int i = 0; i < EnemyBulletCount; i++)
        {
            GameObject object_ = Instantiate(EnemyBulletPrefab);
            object_.transform.parent = gameObject.transform;
            object_.transform.position = Vector3.zero;
            object_.SetActive(false);
            EnemyBulletPool.Push(object_);
        }
    }

    void Update()
    {

    }


    public GameObject PlayerBulletPop()
    {
        return PlayerBulletPool.Pop();
    }

    public void PlayerBulletPush(GameObject obj_)
    {
        obj_.transform.position = Vector3.zero;
        obj_.SetActive(false);
        PlayerBulletPool.Push(obj_);
    }

    public GameObject EnemyBulletPop()
    {
        return EnemyBulletPool.Pop();
    }

    public void EnemyBulletPush(GameObject obj_)
    {
        obj_.transform.position = Vector3.zero;
        obj_.SetActive(false);
        EnemyBulletPool.Push(obj_);
    }
}
