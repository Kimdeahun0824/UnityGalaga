using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZaco : MonoBehaviour, Enemy
{
    private float timeAfterSpawn;
    public GameObject targetPosition;
    public Transform player;
    public float speed = 0f;

    private float timeAfterFire;
    public float fireRateMin = 0.5f;
    public float fireRateMax = 2.5f;
    private float fireRate;
    
    public void Attack()
    {
        timeAfterFire = timeAfterFire +Time.deltaTime;
        
        if(timeAfterFire>=fireRate){
            timeAfterFire=0;

            GameObject bullet = ObjectPoolManager.Instance.EnemyBulletPop();
            bullet.SetActive(true);
            bullet.transform.position = this.transform.position;
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
        timeAfterSpawn = timeAfterSpawn + Time.deltaTime;
        if (timeAfterSpawn < 2)
        {
            //transform.Translate(new Vector3(0,0,-1),Space.World);
            transform.Translate(Vector3.back * speed * Time.deltaTime);

        }
        else if (timeAfterSpawn >= 2 && timeAfterSpawn < 3)
        {
            transform.Rotate(new Vector3(0, 360, 0) * Time.deltaTime);
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (timeAfterSpawn >= 3 && timeAfterSpawn < 4)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (timeAfterSpawn >= 4 && timeAfterSpawn < 5)
        {
            transform.Rotate(new Vector3(0, -360, 0) * Time.deltaTime);
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (timeAfterSpawn >= 5 && timeAfterSpawn < 7)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }


        else
        {
            transform.position =
           Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 20 * Time.deltaTime);
        }


    }

    void Start()
    {
        //gameObject.SetActive(true);
        int random = Random.Range(-15, 15);
        transform.position = new Vector3(random, 0, 28);

        timeAfterFire=0;
        fireRate = Random.Range(fireRateMin,fireRateMax);

    }

    void Update()
    {
        Move();
        Attack();
    }


    public void SetTargetPosition(GameObject obj_){
        targetPosition = obj_;

    }

    void OnTriggerEnter(Collider other){ 

        Debug.Log("sadsadas");
        if(other.tag.Equals("PlayerBullet")){
            Die();
        } 
    }
}
