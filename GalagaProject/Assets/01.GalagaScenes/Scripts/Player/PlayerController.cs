using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody = default;
    public PlayerManager pm;
    public GameObject fire;
    public int player_life = 3;
    public float player_speed = 10f;
    public float max_delay;
    private float cur_delay;
    //float repawntime = 2.0f;
    // Start is called before the first frame update
    //Bullet FireBullet;
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void OnEnable(){
        
    }

    // Enemy와 충돌하면 Die 함수 호출
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy") || other.tag.Equals("EnemyBullet"))
        {
            Die();
        }
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //목표 딜레이 시간을 채우기 전에는 return
            if (cur_delay < max_delay)
            {
                return;
            }

            //딜레이 시간을 채우고 나면 총알 발사

            //bullet을 pop하면서 tag - player설정
            GameObject tempbullet = ObjectPoolManager.Instance.PlayerBulletPop();

            tempbullet.transform.position = transform.position;
            tempbullet.transform.rotation = transform.rotation;
            tempbullet.SetActive(true);
            //딜레이 체크 시간 초기화
            cur_delay = 0;
        }

    }
    void DelayShoot()
    {
        cur_delay = cur_delay + Time.deltaTime;
    }
    // 플레이어 움직이는함수.
    void Move()
    {

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * player_speed;
        float zSpeed = zInput * player_speed;

        Vector3 playerVelo = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidBody.velocity = playerVelo;

        if (playerRigidBody.position.x >= 13)
        {
            playerRigidBody.position = new Vector3(13, 0, playerRigidBody.position.z);
        }
        if (playerRigidBody.position.x <= -13)
        {
            playerRigidBody.position = new Vector3(-13, 0, playerRigidBody.position.z);
        }
        if (playerRigidBody.position.z >= 25)
        {
            if (playerRigidBody.position.x <= -13)
            {
                playerRigidBody.position = new Vector3(-13, 0, -25);
            }
            playerRigidBody.position = new Vector3(playerRigidBody.position.x, 0, 25);
        }
        if (playerRigidBody.position.z <= -25)
        {
            if (playerRigidBody.position.x <= -13)
            {
                playerRigidBody.position = new Vector3(-13, 0, -25);
            }
            else if (playerRigidBody.position.x >= 13)
            {
                playerRigidBody.position = new Vector3(13, 0, -25);
            }
            else
            {
                playerRigidBody.position = new Vector3(playerRigidBody.position.x, 0, -25);

            }
        }

    }
    void Update()
    {
        Move();
        Shoot();
        DelayShoot();
    }

    /* IEnumerator SetPlayer()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        gameObject.SetActive(true);
    } */


    // 플레이어가 죽으면 생명이 깎인다.
    public void Die()
    {
        player_life--;
        if (player_life <= 0)
        {
            //폭발효과 출력
            GameObject fire_instance = Instantiate(fire, transform.position, default);
            Destroy(fire_instance, 2.0f);


            UIManager.Instance.LifeImageUpdate(player_life);
            gameObject.SetActive(false);
            Destroy(gameObject);

            //게임 오버ui출력
            UIManager.Instance.GameOver();
        }
        else
        {
            GameObject fire_instance = Instantiate(fire, transform.position, default);
            Destroy(fire_instance, 2.0f);

            //{피격시 플레이어매니저에서 리스폰 위치 재설정
            pm.Dead();
            pm.RespawnPlayer();
            //player obj 비활성화 후 리스폰 위치 재설정(0,0,-20), 2초 delay 이하 obj활성
            //}피격시 플레이어매니저에서 리스폰 위치 재설정

            //ui매니저에서 라이프 이미지 설정
            UIManager.Instance.LifeImageUpdate(player_life);
            Debug.Log(player_life);
        }
    }
}
