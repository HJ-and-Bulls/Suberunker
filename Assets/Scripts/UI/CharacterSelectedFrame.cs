using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectedFrame : MonoBehaviour
{
    public static int PlayerNum;
    [SerializeField] GameObject[] Player1Frames;
    [SerializeField] GameObject[] Player2Frames;
    
    public void SetPlayerFrame(int selectedCharacter)
    {
        switch (PlayerNum)
        {
            case 0:
                foreach(GameObject frame in Player1Frames)
                    frame.SetActive(false);
                Player1Frames[selectedCharacter].SetActive(true);
                break;
            case 1:
                foreach (GameObject frame in Player2Frames)
                    frame.SetActive(false);
                Player2Frames[selectedCharacter].SetActive(true);
                break;
        }
    }
}
