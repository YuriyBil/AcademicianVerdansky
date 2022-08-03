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


    public static SliderController instanceSliderController = null; // Object instance

    void Awake()
    {
        // Checking for the existence of an instance
        if (instanceSliderController == null)
        { // Іnstance is exists
            instanceSliderController = this; // Set a reference to an object instance
        }
        else if (instanceSliderController == this)
        { // An object instance already exists in the scene
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private SliderPanelsScript helthPersSlider;
    private SliderPanelsScript energyPersSlider;
    private SliderPanelsScript temperatureSlider;
    private SliderPanelsScript foodSlider;
    private SliderPanelsScript waterSlider;

    int ht = 100;
    int p = 10;


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
