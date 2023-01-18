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

    private Stack<GameObject> PrefabPool;
    public GameObject Prefab;
    public int PrefabCount;

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

        PrefabPool = new Stack<GameObject>();
        for (int i = 0; i < PrefabCount; i++)
        {
            GameObject object_ = Instantiate(Prefab);
            object_.transform.parent = gameObject.transform;
            object_.transform.position = Vector3.zero;
            object_.SetActive(false);
            PrefabPool.Push(object_);
        }
    }

    void Update()
    {

    }

    public GameObject ObjPop()
    {
        return PrefabPool.Pop();
    }

    public void ObjPush(GameObject obj)
    {
        obj.transform.position = Vector3.zero;
        obj.SetActive(false);
        PrefabPool.Push(obj);
    }
}
