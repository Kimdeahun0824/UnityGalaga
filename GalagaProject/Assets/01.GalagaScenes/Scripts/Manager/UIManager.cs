using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager myInstance = null;
    public static UIManager Instance
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
    // Start is called before the first frame update
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
}
