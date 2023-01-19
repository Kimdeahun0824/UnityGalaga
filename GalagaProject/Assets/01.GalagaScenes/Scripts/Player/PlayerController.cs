using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody playerRigidBody = default;
   public int player_life = 3;
    private float player_speed = 10f;
    // Start is called before the first frame update
    //Bullet FireBullet;
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();

    }

    // Enemy와 충돌하면 Die 함수 호출
        void OnTriggerEnter(Collider other){ 
            if(other.tag.Equals("Enemy")||other.tag.Equals("Bullet")){
                Die();
            } 
        }
    
    void Shoot()
    {
        if(Input.GetKey(KeyCode.Space)){
            GameObject tempbullet = ObjectPoolManager.Instance.ObjPop();
            tempbullet.transform.position = transform.position;
            tempbullet.SetActive(true);
            
        }
    }
    // 플레이어 움직이는함수.
    void Move(){
        
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput*player_speed;
        float zSpeed = zInput*player_speed;
        
        Vector3 playerVelo = new Vector3(xSpeed, 0f, zSpeed)*player_speed;
       // Debug.Log(playerVelo);
        playerRigidBody.velocity = playerVelo;
        if(playerRigidBody.position.x >=13){
            playerRigidBody.position = new Vector3(13,0,playerRigidBody.position.z);
        }
        if(playerRigidBody.position.x <= -13){
            playerRigidBody.position = new Vector3(-13,0,playerRigidBody.position.z);
        }
        if(playerRigidBody.position.z >=25){
            if(playerRigidBody.position.x <= -13){
                playerRigidBody.position = new Vector3(-13,0,-25);
            }
            playerRigidBody.position = new Vector3(playerRigidBody.position.x,0,25);
        }
        if(playerRigidBody.position.z <=-25){
            if(playerRigidBody.position.x <= -13){
                playerRigidBody.position = new Vector3(-13,0,-25);
            }
            else if(playerRigidBody.position.x >= 13){
                playerRigidBody.position = new Vector3(13,0,-25);
            }
            else{
            playerRigidBody.position = new Vector3(playerRigidBody.position.x,0,-25);

            }
        }

    }
    void Update()
    {
        Move();
        Shoot();
    }

    // 플레이어가 죽으면 생명이 깎인다.
    public void Die(){
        player_life--;
        // 이펙트호출
        //Instantiate(fire, transform.position,default);
        Debug.Log(player_life);
        if(player_life<=0){
            gameObject.SetActive(false);
        }
    }
    void OnDestory(){
    }
}
