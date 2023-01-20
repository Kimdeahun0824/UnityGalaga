using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
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



    //{변수 설정
    private Scene currentScene;
    public TMP_Text ScoreText;
    public Image[] lifeImage;
    public GameObject gameOver;
    private int score;
    //}변수 설정

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
        gameOver.SetActive(false);
        
        currentScene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        // # UI Score 업데이트
        // # UI LifeImage 업데이트
    }

    //{라이프이미지 비활성화(이미지 투명화)
    public void LifeImageUpdate(int life)
    {
        lifeImage[life].color = new Color(1, 1, 1, 0);
    }
    //}라이프이미지 비활성화(이미지 투명화)

    //재시작 버튼 클릭시 실행되는 함수
    public void ClickRe()
    {
        SceneManager.LoadScene("GalagaScene");

        //활성화된 총알 회수
        ObjectPoolManager.Instance.SceneReload();

        Time.timeScale = 1f;
        //gameover ui 비활성
        gameOver.SetActive(false);

        //라이프 이미지 초기화
        foreach(var obj in lifeImage){
            obj.color = new Color(1,1,1,1);
        }

        //PlayerManager.Instance.SetPlayer();
    }

    //플레이어 life 모두 소진시 실행될 함수
    public void GameOver()
    {
        //게임오버 ui 출력
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    //enemy 격추시 스코어 변동, 출력
    public void ScoreAdd(int point){
        score+=point;
        ScoreText.text = "Score\n"+score;
    }
}
