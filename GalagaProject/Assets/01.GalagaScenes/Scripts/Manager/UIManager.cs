using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private static UIManager myInstance = null;
    //public Text scoreText;
    public Image[] lifeImage;
    public GameObject gameOver;

    // Update is called once per frame
    void Start(){
        gameOver.SetActive(false);
    }
    void Update()
    {
        // # UI Score 업데이트
        // # UI LifeImage 업데이트
    }
    public void LifeImageUpdate(int life){
        Debug.Log($"{life}되냐");
        lifeImage[life].color = new Color(1,1,1,0);
    }
    public void ClickRe(){
        Debug.Log("test");
        SceneManager.LoadScene("first");
    }
    public void GameOver(){
        gameOver.SetActive(true);
    }
}
