using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    void Awake(){
        //스크린 사이즈 설정
        Screen.SetResolution(720,1280,true);
    }
}
