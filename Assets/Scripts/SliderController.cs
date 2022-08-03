using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    Slider HealthPers;

    [SerializeField]
    Slider EnergyPers;

    [SerializeField]
    Slider Temperature;

    [SerializeField]
    Slider Food;

    [SerializeField]
    Slider Water;

    private SliderPanelsScript helthPersSlider;
    private SliderPanelsScript energyPersSlider;
    private SliderPanelsScript temperatureSlider;
    private SliderPanelsScript foodSlider;
    private SliderPanelsScript waterSlider;

    int ht = 100;
    int p = 10;

    // void Awake()
    // {
    //  
    // }

    void Start()
    {
        helthPersSlider = new SliderPanelsScript(HealthPers, ht);
        energyPersSlider = new SliderPanelsScript(EnergyPers, ht);
        temperatureSlider = new SliderPanelsScript(Temperature, ht);
        foodSlider = new SliderPanelsScript(Food, ht);
        waterSlider = new SliderPanelsScript(Water, ht);
    }
    void Update()
    {
        helthPersSlider.SliderSetValue(p);
        energyPersSlider.SliderSetValue(p);
        temperatureSlider.SliderSetValue(p);
        foodSlider.SliderSetValue(p);
        waterSlider.SliderSetValue(p);

        helthPersSlider.SliderSetValueOnTime();
        energyPersSlider.SliderSetValueOnTime();
        temperatureSlider.SliderSetValueOnTime();
        foodSlider.SliderSetValueOnTime();
        waterSlider.SliderSetValueOnTime();

        if (Input.GetKeyDown(KeyCode.W))
        {
            helthPersSlider.ToggleIsTime();
            energyPersSlider.ToggleIsTime();
            temperatureSlider.ToggleIsTime();
            foodSlider.ToggleIsTime();
            waterSlider.ToggleIsTime();
        }
    }
}
