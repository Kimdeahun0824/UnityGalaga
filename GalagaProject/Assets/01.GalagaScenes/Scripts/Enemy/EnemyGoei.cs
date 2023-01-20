using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoei : MonoBehaviour, Enemy
{
    //움직임 설정을 위한 time체크용 변수
    private float timeAfterSpawn;

    //이동 패턴 완료 후 목표 지점으로 이동하기 위한 좌표
    public Transform targetPosition;

    //총알 목표 지정(플레이어)을 위한 변수
    private Transform player;

    //{ 총알 발사 주기 설정을 위한 변수
    private float timeAfterFire;
    public float fireRateMin = 0.5f;
    public float fireRateMax = 2.5f;
    private float fireRate;
    //} 총알 발사 주기 설정을 위한 변수

    
    public void Attack()
    {
        timeAfterFire = timeAfterFire + Time.deltaTime;

        //이전 발사 하고 난 뒤 시간이 fireRate 보다 같거나 커지면
        if (timeAfterFire >= fireRate)
        {
            timeAfterFire = 0;

            //pool 에서 bullet을 pop, 활성화, bullet 의 위치를 enemy가 발사 시 위치로 설정, player의 방향을 보도록 설정, 다음 발사 간격을 위한 fireRate 재설정
            GameObject bullet = ObjectPoolManager.Instance.EnemyBulletPop();
            bullet.SetActive(true);
            bullet.transform.position = this.transform.position;
            bullet.transform.LookAt(player);
            fireRate = Random.Range(fireRateMin, fireRateMax);
        }

    }

    //충돌시 트리거 발동
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Bullet : {other.name},{other.tag}");
        //playerBullet 태그를 단 obj와 충돌시 Die 함수 실행
        if (other.tag.Equals("PlayerBullet"))
        {
            Die();
        }
    }
    //playerBullet 태그를 단 obj와 충돌했을때 실행되는 함수
    public void Die()
    {
        //UIManager의 ScoreAdd함수 실행(score+=50)
        UIManager.Instance.ScoreAdd(50);
        //pop했던 enemyPoint를 pool로 push
        EnemyManager.Instance.PointPush(targetPosition.gameObject);
        //obj제거
        Destroy(gameObject);
    }

    public void Move()
    {
        timeAfterSpawn = timeAfterSpawn + Time.deltaTime;

        //5초가 지나면 targetposition으로 이동
        if (timeAfterSpawn > 5)
        {
            transform.position =
            Vector3.MoveTowards(gameObject.transform.position, targetPosition.position, 20 * Time.deltaTime);
        }

        //짝수 초 동안 vector -1,0,-1 방향으로 이동
        else if (timeAfterSpawn % 2 < 1)
        {
            transform.Translate(new Vector3(-1, 0, -1) * 10 * Time.deltaTime);
        }
        //홀수 초 동안 vector 1,0,-1 방향으로 이동
        else if (timeAfterSpawn % 2 > 1)
        { 
            transform.Translate(new Vector3(1, 0, -1) * 10 * Time.deltaTime);

        }


    }

    void Start()
    {
        //생성 좌표 랜덤 설정
        int random = Random.Range(-14, 14);
        transform.position = new Vector3(random, 0, 28);

        //attack 함수를 위한 기본 세팅
        timeAfterFire = 0;
        fireRate = Random.Range(fireRateMin, fireRateMax);

        //선언한 player 변수 설정
        player = Utility.RootGameObjectFind("Player").transform;
    }

    void Update()
    {
        Move();
        Attack();
    }
    public void SetTarget(Transform target_)
    {
        targetPosition = target_;
    }

}
