using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoei : MonoBehaviour, Enemy
{
    private float timeAfterSpawn;
    public GameObject targetPosition;
    public Transform player;
    
    private float timeAfterFire;
    public float fireRateMin = 0.5f;
    public float fireRateMax = 2.5f;
    private float fireRate;
    
    public void Attack()
    {
        timeAfterFire = timeAfterFire +Time.deltaTime;
        
        if(timeAfterFire>=fireRate){
            timeAfterFire=0;

            GameObject bullet = ObjectPoolManager.Instance.ObjPop();
            bullet.SetActive(true);
            bullet.transform.position=this.transform.position;
            bullet.transform.LookAt(player);
            fireRate = Random.Range(fireRateMin,fireRateMax);
        }

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

        timeAfterFire=0;
        fireRate = Random.Range(fireRateMin,fireRateMax);
    }

    void Update()
    {
        Move();
        Attack();
    }

    
}
