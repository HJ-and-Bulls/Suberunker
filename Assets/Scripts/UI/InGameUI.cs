using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] Text _score;
    [SerializeField] Text _time;

    void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
        GameManager.Instance.OnTimeChanged += UpdateTimeText;
    }

    void UpdateScoreText(int score)
    {
        _score.text = score.ToString();
    }

    void UpdateTimeText(float time)
    {
        int timeToInt = Mathf.FloorToInt(time);
        int minute = timeToInt / 60;
        int second = timeToInt % 60;
        _time.text = $"{minute.ToString("D2")}:{second.ToString("D2")}";
    }
}
