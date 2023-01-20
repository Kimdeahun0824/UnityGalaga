using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager myInstance = null;
    public static EnemyManager Instance
    {
        get
        {
            if (myInstance == null)
            {
                return null;
            }
            else
            {
                return myInstance;
            }
        }
    }

    //gameobject Enemy 배열 생성
    public GameObject[] Enemys;
    //inspector에서 EnemyZaco, Goei 입력

    //gameobject Enemy 스폰 주기 설정/inspector에서 3으로 입력
    public float EnemySpawnRate;
    
    private bool IsSpawn;

    //(적이 이동 패턴 완료 후 돌아가기 위한 좌표) stack을 만들고 - *1
    private Stack<GameObject> enemyPoint;

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

        //update 함수 실행되도록 시작시 isSpawn true로
        IsSpawn = true;

        //enemypoint 스택 초기화
        enemyPoint = new Stack<GameObject>();

        // *1 - 씬 목록에서 field의 자식 오브젝트(point)의 좌표를 추출해서 배열에 입력
        Transform[] objs = Utility.RootGameObjectFind("Field").GetComponentsInChildren<Transform>();
        foreach(var obj in objs){
            if(obj.name == "Field")continue;
            enemyPoint.Push(obj.gameObject);
        }
    }

    void Update()
    {
        if (IsSpawn)
        {
            IsSpawn = false;
            //inspector에서 입력한 enemy 배열에서 랜덤으로 스폰될 obj 설정)
            int randNum = Random.Range(0, Enemys.Length);

            //obj만들면서 enemyPoint를 설정해줌.
            Instantiate(Enemys[randNum]).GetComponent<Enemy>().SetTarget(enemyPoint.Pop().transform);

            //enemyspawn 코루틴 설정
            StartCoroutine("Enemyspawn");
        }
    }
    //스폰 주기 - 3초 뒤에 isSpawn true로 전환해서 if문 다시 실행되도록
    IEnumerator Enemyspawn()
    {
        yield return new WaitForSeconds(EnemySpawnRate);
        IsSpawn = true;
    }

    //pop 했던 enemy point stack에 push(죽었을때 발동하도록 enemy scrip에 설정)
    public void PointPush(GameObject obj_){
        enemyPoint.Push(obj_);
    }




}
