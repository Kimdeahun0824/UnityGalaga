using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody playerRigidBody = default;
   public int player_life = 3;
    public float player_speed = 10000f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();

    }

    // 다른 오브젝트와 충돌하면 Die 함수 호출
    void OnTriggerEnter(Collider other){ 
        if(other.tag.Equals("Enemy")){
            Die();
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
        if(playerRigidBody.position.x >=10){
            playerRigidBody.position = new Vector3(10,0,playerRigidBody.position.z);
        }
        if(playerRigidBody.position.x <= -10){
            playerRigidBody.position = new Vector3(-10,0,playerRigidBody.position.z);
        }
        if(playerRigidBody.position.z >=10){
            playerRigidBody.position = new Vector3(playerRigidBody.position.x,0,10);
        }
        if(playerRigidBody.position.z <=-10){
            playerRigidBody.position = new Vector3(playerRigidBody.position.x,0,-10);
        }

    }
    void Update()
    {
        Move();
    }

    // 플레이어가 죽으면 생명이 깎인다.
    public void Die(){
        player_life--;
        Debug.Log(player_life);
        if(player_life<=0){
            gameObject.SetActive(false);
        }
    }
    void OnDestory(){
    }
}
