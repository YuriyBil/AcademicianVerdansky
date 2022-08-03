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

    public void SliderSetValue(int param)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _slider.value = _slider.value - param;
        }
    }

    public void SliderSetValueOnTime()
    {
        if (isTime)
        {
            _slider.value = _slider.value - Time.deltaTime * 10;
        }

    }

    public SliderPanelsScript(Slider slider, int maxValue)
    {
        this._slider = slider;
        SetMaxValue(maxValue);
    }

    bool isTime = false;

    public void ToggleIsTime()
    {
        isTime = !isTime;
    }
}

