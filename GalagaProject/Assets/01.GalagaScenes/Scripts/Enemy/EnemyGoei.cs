using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoei : MonoBehaviour, Enemy
{
    private float timeAfterSpawn;
    public GameObject targetPosition;
    
    public void Attack()
    {
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Move()
    {
        timeAfterSpawn = timeAfterSpawn +Time.deltaTime;

        if(timeAfterSpawn >5){
            transform.position =
            Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position , 20*Time.deltaTime);
        }
        
        else if(timeAfterSpawn%2<1){
            transform.Translate(new Vector3(-1,0,-1)*10*Time.deltaTime);
        }
        else if(timeAfterSpawn%2>1){ //>=1&&timeAfterSpawn <2){
            transform.Translate(new Vector3(1,0,-1)*10*Time.deltaTime);

        }
        
        
    }

    void Start()
    {
        
        int random = Random.Range(-15,15);
        transform.position = new Vector3(random, 0, 28);
    }

    void Update()
    {
        Move();
    }

    
}
