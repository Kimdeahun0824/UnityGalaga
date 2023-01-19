using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum EnemyTypes{
        ZACO,GOEI,
    }
    public GameObject[] Enemys;
    private static EnemyManager myInstance = null;
    public static EnemyManager Instance
    {
        get
        {
            if (myInstance == null)
            {
                return null;
            }
            else
            {
                return myInstance;
            }
        }
    }

    public float EnemySpawnRate;
    private float currentSpawnTimer;

    void Awake()
    {
        if (myInstance == null)
        {
            myInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (currentSpawnTimer > EnemySpawnRate)
        {
            currentSpawnTimer = 0;
            EnemySpawn();
        }
        else
        {
            currentSpawnTimer += Time.deltaTime;
        }
    }
    public void EnemySpawn()
    {
        //int randNum = Random.RandomRange(0,Enemys.Length);
        Instantiate(Enemys[0]);

    }

    public void EnemyGoeiSpawn()
    {
        
    }
    public void EnemyZacoSpawn()
    {

    }
}
