using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private AudioClip BGM_Start;
    [SerializeField] private AudioClip BGM_InGame;
    [SerializeField] private AudioClip Sound_ShiledOn;
    [SerializeField] private AudioClip Sound_ShiledOff;
    [SerializeField] private AudioClip Sound_Die;

    private AudioSource BGM;
    private AudioSource Sound;


    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.volume = 0.2f;
        BGM.loop = true;

        Sound = gameObject.AddComponent<AudioSource>();
        Sound.volume = 0.3f;

        BGM.clip = BGM_Start;
        BGM.Play();

    }

    public void SetBGM_InGame()
    {
        BGM.clip = BGM_InGame;
        BGM.Play();
    }

    public void PlayShieldSound(bool isOn)
    {
        Sound.clip = isOn ? Sound_ShiledOn : Sound_ShiledOff;
        Sound.Play();
    }

    public void PlayDieSound()
    {
        Sound.clip = Sound_Die;
        Sound.Play();
    }
}
