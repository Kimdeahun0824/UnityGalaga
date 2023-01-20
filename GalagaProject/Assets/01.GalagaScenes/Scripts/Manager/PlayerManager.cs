using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager myInstance = null;
    public static PlayerManager Instance
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
    private GameObject player;
    void Awake()
    {
        if (myInstance == null)
        {
            myInstance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }

        //scene에서 Player를 찾아 선언한 palyer Gameoject에 입력
        player = Utility.RootGameObjectFind("Player");
    }

    void OnEnable()
    {

    }
    // Update is called once per frame
    void Update()
    {
    }
    
    //총알에 피격시 실행할 함수 - 1
    public void Dead()
    {
        player.SetActive(false);
    }

    //총알에 피격시 실행할 함수 - 2
    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerexe", 2f);
    }
    
    //총알에 피격시 실행할 함수 - 2-1
    public void RespawnPlayerexe()
    {
        player.transform.position = new Vector3(0, 0, -20);
        player.SetActive(true);
    }
    //player obj 비활성화 후 리스폰 위치 재설정(0,0,-20), 2초 delay 이하 obj활성

    

    /* public void SetPlayer()
    {
        player = Utility.RootGameObjectFind("Player");
    } */


}
