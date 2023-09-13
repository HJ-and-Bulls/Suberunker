using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterUI : MonoBehaviour
{
    private bool isReady;
    private int selectingPlayer;

    private void Start()
    {
        selectingPlayer = -1;
    }

    public void SetPlayerCharacter(int code)
    {
        selectingPlayer = ++selectingPlayer % StartManager.Instance.PlayerNumber;
        CharacterSelectedFrame.PlayerNum = selectingPlayer;
        StartManager.Instance.SetCharacterCode(selectingPlayer, code);
        if (selectingPlayer == StartManager.Instance.PlayerNumber - 1) isReady = true;
    }

    public void GameStart()
    {
        if (isReady == false) return;
        SceneManager.LoadScene("MainScene");
    }
}
