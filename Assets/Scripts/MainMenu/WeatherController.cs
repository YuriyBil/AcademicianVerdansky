using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherController : MonoBehaviour
{
    public GameObject SnowFall;
    public GameObject Storm;
    public GameObject Blizzard;

    [SerializeField] private Button _snowFall;
    [SerializeField] private Button _storm;
    [SerializeField] private Button _blizzard;


    public bool SnowFallActive = false;
    public bool StormActive = false;
    public bool BlizzardActive = false;

    void OnEnable()
    {
        _snowFall.onClick.AddListener(GoSnowFall);
        _storm.onClick.AddListener(GoStorm);
        _blizzard.onClick.AddListener(GoBlizzard);
    }

    void OnDisable()
    {
        _snowFall.onClick.RemoveListener(GoSnowFall);
        _storm.onClick.RemoveListener(GoStorm);
        _blizzard.onClick.RemoveListener(GoBlizzard);
    }

    void GoSnowFall()
    {
        StormActive = false;
        BlizzardActive = false;
        SnowFallActive = !SnowFallActive;
        ChangeWeather();
    }

    void GoStorm()
    {
        SnowFallActive = false;
        BlizzardActive = false;
        StormActive = !StormActive;
        ChangeWeather();
    }

    void GoBlizzard()
    {
        SnowFallActive = false;
        StormActive = false;
        BlizzardActive = !BlizzardActive;
        ChangeWeather();
    }

    private void ChangeWeather()
    {
        Storm.SetActive(StormActive);
        Blizzard.SetActive(BlizzardActive);
        SnowFall.SetActive(SnowFallActive);
    }

    public void CancelWeather()
    {
        Storm.SetActive(false);
        Blizzard.SetActive(false);
        SnowFall.SetActive(false);
    }

}
