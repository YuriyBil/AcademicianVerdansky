using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DayTimeController : MonoBehaviour
{
    public List<Sprite> ListSpriteDayTime;
    public Image Image;

    public Button Nigtht;
    public Button Dawn;
    public Button Day;
    public Button Dusk;

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
        ChangeDaySprite(0);
    }

    void GoDay()
    {
        ChangeDaySprite(1);
    }

    void GoDusk()
    {
        ChangeDaySprite(2);
    }

    private void ChangeDaySprite(int i)
    {
        Image.sprite = ListSpriteDayTime[i];
    }

    void Update()
    {
        //ChangeBG(DateTime.Now);

    }

}
