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


    public static SliderController instance = null; // Object instance

    void Awake()
    {
        // Checking for the existence of an instance
        if (instance == null)
        { // Іnstance is exists
            instance = this; // Set a reference to an object instance
        }
        else if (instance == this)
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
    float p = 10f;
    bool isT = false;



    void Start()
    {
        helthPersSlider = new SliderPanelsScript(HealthPers, ht);
        energyPersSlider = new SliderPanelsScript(EnergyPers, ht);
        temperatureSlider = new SliderPanelsScript(Temperature, ht);
        foodSlider = new SliderPanelsScript(Food, ht);
        waterSlider = new SliderPanelsScript(Water, ht);
    }

    void KeyCodeInput()
    {
        float tp = Time.deltaTime * 10;


        if (Input.GetKeyDown(KeyCode.Q))
        {
            helthPersSlider.SliderSetValue(-p);
            energyPersSlider.SliderSetValue(-p);
            temperatureSlider.SliderSetValue(-p);
            foodSlider.SliderSetValue(-p);
            waterSlider.SliderSetValue(-p);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            helthPersSlider.SliderSetValue(p);
            energyPersSlider.SliderSetValue(p);
            temperatureSlider.SliderSetValue(p);
            foodSlider.SliderSetValue(p);
            waterSlider.SliderSetValue(p);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            isT = !isT;
            timeDirection = "up";
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            isT = !isT;
            timeDirection = "down";
        }
    }
    string timeDirection;
    void Update()
    {
        KeyCodeInput();

        if (isT)
        {
            float tp = Time.deltaTime * 10;
            if (timeDirection == "up")
            {
                tp = -tp;
            }
            helthPersSlider.SliderSetValue(tp);
            energyPersSlider.SliderSetValue(tp);
            temperatureSlider.SliderSetValue(tp);
            foodSlider.SliderSetValue(tp);
            waterSlider.SliderSetValue(tp);
        }
    }
}
