using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //public enum InfoType {  Time, Score }
    //public InfoType type;

    Text myText;


    public void SetTimeUI(float time)
    {
        myText = GetComponent<Text>();
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        myText.text = string.Format("{0:D2}:{1:D2}",min,sec);
    }
    public void SetScoreUI(int score)
    {
        myText = GetComponent<Text>();
        myText.text = score.ToString("C2");
    }
}
