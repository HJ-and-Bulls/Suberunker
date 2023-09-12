using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterUI : MonoBehaviour
{
    public int playerId;
    public void ValidSelectPlayer()
    {
        if (playerId >= 0)
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("MainScene");
        }
     }

    //private void 

}
