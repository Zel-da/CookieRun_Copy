using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // 싱글턴을 할당할 전역 변수

    public bool isGameover = false; // 게임오버 상태
    public Text scoreText; //점수를 출력할 UI 텍스트
    public GameObject gameoverUI; // 게임 오버 시 활성화 할 UI 게임 오브젝트

    private int score = 0; // 게임 점수

    //게임 시작과 동시에 싱글턴 구성
    void Awake()
    {
        //싱글턴 변수 instance가 비어있는가?
        if (instance == null)
        {
            //instance가 비어있다면 (null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            //instance에 이미 다른 GameObject가 할당되어 있는 경우

            //씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미
            //싱글턴 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void GameRestart()
    {
        //게임 오버 상태에서 게임을 재시작 할 수 있게하는 처리
        if (isGameover)
        {
            //게임오버 상타에서 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //점수를 장가시키는 메서드
    public void AddStore(int newStore)
    {
        if (!isGameover)
        {
            //점수를 증가
            score += newStore;
            scoreText.text = "Score : " + score;
        }
    }

    //플레이어 캐릭터 사망 시 게임오버를 실행하는 메서드
    public void OnPlayerDead()
    {
        //현재 상태를 게임오버 상태로 변경
        isGameover = true;
        //게임오버 UI를 활성화
        gameoverUI.SetActive(true);
    }
}
