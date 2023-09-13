using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public static StartManager Instance = null;

    public bool IsHard;
    public int PlayerNumber;
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
        if (playerNum >= CharacterCodes.Length)
        {
            int[] newCharacterCodes = new int[playerNum];
            CharacterCodes.CopyTo(newCharacterCodes, 0);
            CharacterCodes = newCharacterCodes;
        }
        
        CharacterCodes[playerNum] = code;
    }
}
