using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Dead(){
        Debug.Log("ddsad");
        player.SetActive(false);
    }
    public void RespawnPlayerexe(){
        player.transform.position = Vector3.zero;
        player.SetActive(true);
    }
    public void RespawnPlayer(){
        Invoke("RespawnPlayerexe",2f);
    }
}
