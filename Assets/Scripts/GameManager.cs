using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float _gameTime;
    public float GameTime
    {
        get { return _gameTime; }
        set
        {
            _gameTime = value;
            OnTimeChanged?.Invoke(value);
        }
    }
    public event Action<float> OnTimeChanged;

    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreChanged?.Invoke(value);
        }
    }
    public event Action<int> OnScoreChanged;

    // 게임 관리 이벤트
    public event Action OnGameStart;
    public event Action OnGameEnd;


    void Awake()
    {
        // 싱글톤 패턴
        Instance = this;
    }

    void Start()
    {
        // 이벤트 초기화
        OnGameStart += InitGame;
        OnGameEnd += StopGame;

        CallbackGameStart();
    }

    void CallbackGameStart()
    {
        OnGameStart?.Invoke();
    }

    // OnGameEnd를 호출하기 위한 함수입니다.
    void CallbackGameEnd()
    {
        OnGameEnd?.Invoke();
    }

    void InitGame()
    {
        Time.timeScale = 1f;
        Score = 0;
        GameTime = 0f;
    }

    void StopGame()
    {
        Time.timeScale = 0f;
    }
}
