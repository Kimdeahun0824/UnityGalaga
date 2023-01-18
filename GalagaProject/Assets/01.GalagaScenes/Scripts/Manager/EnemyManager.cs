using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemySpawn(string name)
    {

    }
}
