using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class WeatherController : MonoBehaviour
{
    public static WeatherController Instance;
    public ParticleSystem SnowFall;
    public VideoPlayer Storm;
    public VideoClip ClipStorm;

    public GameObject PanelStorm;

    //public GameObject Img;
    public ParticleSystem Blizzard;
    //public ParticleSystem Storm;


    [SerializeField] private Button _snowFall;
    [SerializeField] private Button _storm;
    [SerializeField] private Button _blizzard;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void OnEnable()
    {
        _snowFall.onClick.AddListener(GoSnowFall);
        _storm.onClick.AddListener(GoStorm);
        _blizzard.onClick.AddListener(GoBlizzard);
    }

    void OnDisable()
    {
        _snowFall.onClick.AddListener(CancelWeather);
        _storm.onClick.AddListener(CancelWeather);
        _blizzard.onClick.RemoveListener(CancelWeather);
    }

    void GoSnowFall()
    {
        Storm.Stop();
        PanelStorm.SetActive(false);
        Blizzard.Stop();

        if (SnowFall.isPlaying)
        {
            SnowFall.Stop();
        }
        else
        {
            SnowFall.Play();
        }
    }

    void GoStorm()
    {
        SnowFall.Stop();
        Blizzard.Stop();
        PanelStorm.SetActive(true);

        if (Storm.isPlaying)
        {
            Storm.Stop();
            PanelStorm.SetActive(false);
        }
        else
        {
            Storm.clip = ClipStorm;
            Storm.Play();
        }
    }

    void GoBlizzard()
    {
        SnowFall.Stop();
        Storm.Stop();
        PanelStorm.SetActive(false);

        if (Blizzard.isPlaying)
        {
            Blizzard.Stop();
        }
        else
        {
            Blizzard.Play();
        }
    }

    public void CancelWeather()
    {
        Blizzard.Stop();
        SnowFall.Stop();
        Storm.Stop();
        PanelStorm.SetActive(false);
    }

}
