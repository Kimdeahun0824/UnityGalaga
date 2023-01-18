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
            ObjectPoolManager.Instance.ObjPush(gameObject);
        }
    }
    void Update(){
        // z축으로 계속 더해서 간다.
        transform.localPosition += Vector3.forward * speed * Time.deltaTime;
        //if(gameObject.)
    }
}
