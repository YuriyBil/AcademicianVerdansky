using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPanelsScript
{
    private Slider _slider;

    public void SetMaxValue(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void SliderSetValue(float param)
    {
        _slider.value = _slider.value - param;
    }


    public SliderPanelsScript(Slider slider, int maxValue)
    {
        this._slider = slider;
        SetMaxValue(maxValue);
    }
}

