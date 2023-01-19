using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Player;
    public float speed = 8.0f;
   
    void OnEnable(){
    
    }

    void OnTriggerEnter(Collider other){
        if(other.tag.Equals("Player")){
            ObjectPoolManager.Instance.PlayerBulletPush(gameObject);
        }
    }
    void Update(){
        // z축으로 계속 더해서 간다.
<<<<<<< HEAD
        //transform.localPosition += Vector3.forward * speed * Time.deltaTime;
        transform.Translate(Vector3.forward* speed * Time.deltaTime);
=======
        transform.position += transform.forward * speed * Time.deltaTime;
>>>>>>> 955b402fb0bc76f1f8f306e136342d7af27e89f6
        //if(gameObject.)
    }
}
