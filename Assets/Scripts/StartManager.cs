using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public static StartManager Instance = null;

    public bool IsHard;
    private int _playerNumber;
    public int PlayerNumber
    {
        get { return _playerNumber; }
        set
        {
            _playerNumber = value;
            if (_playerNumber >= CharacterCodes.Length)
            {
                int[] newCharacterCodes = new int[_playerNumber];
                CharacterCodes.CopyTo(newCharacterCodes, 0);
                CharacterCodes = newCharacterCodes;
            }
        }
    }
    public int[] CharacterCodes;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        IsHard = false;
        PlayerNumber = 1;
        CharacterCodes = new int[1];
    }

    public void SetCharacterCode(int playerNum, int code)
    {
        CharacterCodes[playerNum] = code;
    }
}
