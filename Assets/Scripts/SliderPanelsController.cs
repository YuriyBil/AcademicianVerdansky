using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPanelsController
{
    private Slider _slider;

    public void SetMaxValue(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void SliderSetValue(float param)
    {
        float newValue = _slider.value - param;

        if (newValue <= 0)
        {
            newValue = 0;
        }

        if (newValue >= _slider.maxValue)
        {
            newValue = _slider.maxValue;
        }

        _slider.value = newValue;
    }


    public SliderPanelsController(Slider slider, int maxValue)
    {
        this._slider = slider;
        SetMaxValue(maxValue);
    }
}

