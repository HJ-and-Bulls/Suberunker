using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    public void SetPlayerNumber(int number)
    {
        StartManager.Instance.PlayerNumber = number;
        SceneManager.LoadScene("CharacterScene");
    }
}
