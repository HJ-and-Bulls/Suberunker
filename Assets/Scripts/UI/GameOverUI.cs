using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPopUp;
    
    void Start()
    {
        GameManager.Instance.OnGameEnd += () => { _gameOverPopUp.SetActive(true); };
    }

    public void Btn_Retry()
    {
        _gameOverPopUp.SetActive(false);
        GameManager.Instance.InitGame();
    }

    public void Btn_Stop()
    {
        SceneManager.LoadScene("StartScene");
    }
}
