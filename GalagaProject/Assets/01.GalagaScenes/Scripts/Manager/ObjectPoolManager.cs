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

    
    private Stack<GameObject> BulletPool;
    //prefab 입력을 위한 오브젝트
    public GameObject BulletPrefab;
    //생성할 총알 개수
    public int BulletCount;


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
        //pool 초기화
        BulletPool = new Stack<GameObject>();
        //입력한 count만큼 bullet 생성해서 stack에 입력(inspector에서 500으로설정)
        for (int i = 0; i < BulletCount; i++)
        {
            GameObject object_ = Instantiate(BulletPrefab);

            //생성할 위치 설정
            object_.transform.parent = gameObject.transform;
            object_.transform.position = Vector3.zero;

            //비활성상태로 생성하기 위해 setactive false로 입력
            object_.SetActive(false);

            BulletPool.Push(object_);
        }
    }

    //{pop할때 bullet에 tag 설정을 위한 함수 player/enemy
    public GameObject PlayerBulletPop()
    {
        GameObject bullet = BulletPool.Pop();
        bullet.tag = "PlayerBullet";
        return bullet;
    }

    public GameObject EnemyBulletPop()
    {
        GameObject bullet = BulletPool.Pop();
        bullet.tag = "EnemyBullet";
        return bullet;
    }
    //}pop할때 bullet에 tag 설정을 위한 함수 player/enemy

    //{사용된 bullet stack에 다시 수납
    public void BulletPush(GameObject obj_)
    {
        obj_.transform.position = Vector3.zero;
        obj_.SetActive(false);
        BulletPool.Push(obj_);
    }
    //}사용된 bullet stack에 다시 수납

    //{씬 리로드 할때 화면의 bullet들 회수하기 위한 함수
    public void SceneReload()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            BulletPush(transform.GetChild(i).gameObject);
        }
    }
    //}씬 리로드 할때 화면의 bullet들 회수하기 위한 함수

}
