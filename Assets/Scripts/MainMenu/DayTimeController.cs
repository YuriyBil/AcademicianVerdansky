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
    private int i = 0;
    public DateTime CurrentDateTime = DateTime.Now;

    public void ChangeBG(DateTime dateTime)
    {
        if (dateTime.Hour >= 14f)
        {
            i++;
            Image.sprite = ListSpriteDayTime[i];
        }
    }
    void Update()
    {
        ChangeBG(CurrentDateTime);
    }

}
