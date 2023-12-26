using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int _difficulty;
    private int _numberOfAlives = 1;
    public int NumberOfAlives
    {
        get { return _numberOfAlives; }
        set
        {
            _numberOfAlives = value;
            if (_numberOfAlives <= 0)
                //OnGameEnd?.Invoke();
                EventBus.Publish(EventType.GAMEEND);
        }
    }

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
        Instance = this;
    }

    void Start()
    {
        // 이벤트 초기화
        // OnGameStart += InitGame;
        // OnGameStart += AudioManager.Instance.SetBGM_InGame;
        // OnGameEnd += StopGame;
        //
        // OnGameStart?.Invoke();
        EventBus.SubScribe(EventType.GAMESTART, InitGame);
        EventBus.SubScribe(EventType.GAMESTART, AudioManager.Instance.SetBGM_InGame);
        EventBus.SubScribe(EventType.GAMEEND, StopGame);
        
        EventBus.Publish(EventType.GAMESTART);
    }

    void Update()
    {
        GameTime += Time.deltaTime;
    }

    public void InitGame()
    {
        CharacterManager.Instance.ClearCharacterArray();
        if (ObjectPoolingManager.SharedInstance.Pools.ContainsKey("Poop"))
            foreach (GameObject poops in ObjectPoolingManager.SharedInstance.Pools["Poop"])
                poops.SetActive(false);
        if (ObjectPoolingManager.SharedInstance.Pools.ContainsKey("Item"))
            foreach (GameObject poops in ObjectPoolingManager.SharedInstance.Pools["Item"])
                poops.SetActive(false);

        Time.timeScale = 1f;
        Score = 0;
        GameTime = 0f;
        NumberOfAlives = StartManager.Instance.PlayerNumber;
        _difficulty = StartManager.Instance.IsHard ? 2 : 1;
        for (int i = 0; i < NumberOfAlives; i++)
        {
            GameObject generatedCharacter = CharacterManager.Instance.MakeCharacter(StartManager.Instance.CharacterCodes[i]);
            generatedCharacter.GetComponent<Player>().OnDead += PlayerDeadCallback;
        }
    }

    void StopGame()
    {
        Time.timeScale = 0f;
        // 게임 종료 시 HUD.SetActive 로 안보이게 하기
    }

    void PlayerDeadCallback()
    {
        --NumberOfAlives;
    }

    public void AddScore()
    {
        Score += NumberOfAlives * _difficulty; // 1은 난이도에 따라 증가

    }
}
