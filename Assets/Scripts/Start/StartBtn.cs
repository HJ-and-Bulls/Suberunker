using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void Level()
    {
        SceneManager.LoadScene("LevelScene");
    }
    
}
