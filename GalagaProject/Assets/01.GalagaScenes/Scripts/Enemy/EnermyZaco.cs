using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyZaco : MonoBehaviour, Enemy
{
    private float timeAfterSpawn;
    public GameObject targetPosition;
    public float speed = 0f;
    
    public void Attack()
    {
        timeAfterSpawn = timeAfterSpawn +Time.deltaTime;
        if(timeAfterSpawn%2==1){
            
        ObjectPoolManager.Instance.ObjPop();
        
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    
    public void Move()
    {
        
        
        timeAfterSpawn = timeAfterSpawn +Time.deltaTime;
        if(timeAfterSpawn <2){
            //transform.Translate(new Vector3(0,0,-1),Space.World);
            transform.Translate(Vector3.back*speed*Time.deltaTime);
            
        }
        else if(timeAfterSpawn >=2&&timeAfterSpawn <3){
            transform.Rotate(new Vector3(0,360,0)*Time.deltaTime);
            transform.Translate(Vector3.back*speed*Time.deltaTime);
        }
        else if(timeAfterSpawn >=3&&timeAfterSpawn <4){
            transform.Translate(Vector3.back*speed*Time.deltaTime);
        }
        else if(timeAfterSpawn >=4&&timeAfterSpawn <5){
            transform.Rotate(new Vector3(0,-360,0)*Time.deltaTime);
            transform.Translate(Vector3.back*speed*Time.deltaTime);
        }
        else if(timeAfterSpawn >=5&&timeAfterSpawn <7){
            transform.Translate(Vector3.back*speed*Time.deltaTime);
        }


        else{
             transform.position =
            Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position , 20*Time.deltaTime);
        }

        //if(transform.position.z <= -13){
        //    OutBoard();
        //}

    }

    void Start()
    {
        //gameObject.SetActive(true);
        int random = Random.Range(-15,15);
        transform.position = new Vector3(random, 0, 28);
    }

    void Update()
    {
        Move();
        //this.transform.LookAt(player);
        Attack();
    }

    /* public void OutBoard(){
        gameObject.SetActive(false);

    } */
}
