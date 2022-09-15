using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class DayTimeController : MonoBehaviour
{
    public List<Sprite> ListSpriteDayTime;
    public Image Image;
    public GameObject BG;

    public Button Nigtht;
    public Button Dawn;
    public Button Day;
    public Button Dusk;

    public VideoPlayer DayAndNight;
    public VideoClip DawnClip;
    public VideoClip DayClip;
    public GameObject PanelDayTime;

    public void ChangeBG(DateTime dateTime)
    {
        int i = 3;
        int partOfDay = dateTime.Hour;

        if (partOfDay >= 5 && partOfDay < 9)
        {
            i = 0;
        }
        else if (partOfDay >= 9 && partOfDay < 17)
        {
            i = 1;
        }
        else if (partOfDay >= 17 && partOfDay < 21)
        {
            i = 2;
        }

        Image.sprite = ListSpriteDayTime[i];
    }

    void OnEnable()
    {
        Nigtht.onClick.AddListener(GoNight);
        Dawn.onClick.AddListener(GoDawn);
        Day.onClick.AddListener(GoDay);
        Dusk.onClick.AddListener(GoDusk);
    }

    void GoNight()
    {
        ChangeDaySprite(3);
    }

    void GoDawn()
    {
        BG.SetActive(false);
        PanelDayTime.SetActive(true);
        DayAndNight.Stop();
        DayAndNight.clip = DawnClip;
        DayAndNight.Play();
    }

    void GoDay()
    {
        BG.SetActive(false);
        PanelDayTime.SetActive(true);
        DayAndNight.Stop();
        DayAndNight.clip = DayClip;
        DayAndNight.Play();
    }

    void GoDusk()
    {
        ChangeDaySprite(2);
    }

    private void ChangeDaySprite(int i)
    {
        PanelDayTime.SetActive(false);
        BG.SetActive(true);
        Image.sprite = ListSpriteDayTime[i];
    }

    void Update()
    {
        //ChangeBG(DateTime.Now);

    }

}
