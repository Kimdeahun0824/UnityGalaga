using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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

    }
}
