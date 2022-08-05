using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPanelsController
{
    public Slider SliderUI;

    public void SetMaxValue(int health)
    {
        SliderUI.maxValue = health;
        SliderUI.value = health;
    }

    public void SliderSetValue(float param)
    {
        float newValue = SliderUI.value + param;

        if (newValue <= 0)
        {
            newValue = 0;
        }

        if (newValue >= SliderUI.maxValue)
        {
            newValue = SliderUI.maxValue;
        }

        SliderUI.value = newValue;
    }


    public SliderPanelsController(Slider slider, int maxValue)
    {
        this.SliderUI = slider;
        SetMaxValue(maxValue);
    }

}

