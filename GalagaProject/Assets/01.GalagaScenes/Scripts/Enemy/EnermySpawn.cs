using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int random = Random.Range(-6,6);
        transform.position = new Vector3(random, 0, 12);
    }
}
