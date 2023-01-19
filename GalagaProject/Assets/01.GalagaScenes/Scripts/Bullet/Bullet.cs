using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< HEAD
    //private Vector3 direction;
    public void Start()
    {
        //this.direction = direction;

        Destroy(gameObject, 5f);
    }

    void Update()
    {
        //transform.Translate(direction);   
        transform.Translate(new Vector3(0,0,1));

=======
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
>>>>>>> 530f602579843128320301179712dd07f68fbfd8
    }
}
