using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyBtn : MonoBehaviour
{
    public void Easy()
    {
        StartManager.Instance.IsHard = false;
        SceneManager.LoadScene("1P2P");
    }
}
