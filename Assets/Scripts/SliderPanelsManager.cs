using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPanelsManager : MonoBehaviour
{
    [SerializeField]
    private Slider _healthPers;

    [SerializeField]
    private Slider _energyPers;

    [SerializeField]
    private Slider _temperature;

    [SerializeField]
    private Slider _food;

    [SerializeField]
    private Slider _water;

    public SliderPanelsController HelthPersSlider;
    public SliderPanelsController EnergyPersSlider;
    public SliderPanelsController TemperatureSlider;
    public SliderPanelsController FoodSlider;
    public SliderPanelsController WaterSlider;

    private int _hp = 100;
    private float _dValue = 10f;
    private bool _isTime = false;
    private string _timeDirection;


    public static SliderPanelsManager Instance; // Object instance

    void Awake()
    {
        // Checking for the existence of an instance
        if (Instance == null)
        { // Іnstance is exists
            Instance = this; // Set a reference to an object instance
        }
        // else if (Instance == this)
        // { // An object instance already exists in the scene
        //     Destroy(gameObject);
        // }
        DontDestroyOnLoad(gameObject);
    }





    void Start()
    {
        HelthPersSlider = new SliderPanelsController(_healthPers, _hp);
        EnergyPersSlider = new SliderPanelsController(_energyPers, _hp);
        TemperatureSlider = new SliderPanelsController(_temperature, _hp);
        FoodSlider = new SliderPanelsController(_food, _hp);
        WaterSlider = new SliderPanelsController(_water, _hp);
    }

    void KeyCodeInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HelthPersSlider.SliderSetValue(-_dValue);
            EnergyPersSlider.SliderSetValue(-_dValue);
            TemperatureSlider.SliderSetValue(-_dValue);
            FoodSlider.SliderSetValue(-_dValue);
            WaterSlider.SliderSetValue(-_dValue);
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            HelthPersSlider.SliderSetValue(_dValue);
            EnergyPersSlider.SliderSetValue(_dValue);
            TemperatureSlider.SliderSetValue(_dValue);
            FoodSlider.SliderSetValue(_dValue);
            WaterSlider.SliderSetValue(_dValue);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            _isTime = !_isTime;
            _timeDirection = "down";
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            _isTime = !_isTime;
            _timeDirection = "up";
        }
    }

    void Update()
    {
        KeyCodeInput();

        if (_isTime)
        {
            float timeParametr = Time.deltaTime * 10;

            if (_timeDirection == "down")
            {
                timeParametr = -timeParametr;
            }

            HelthPersSlider.SliderSetValue(timeParametr);
            EnergyPersSlider.SliderSetValue(timeParametr);
            TemperatureSlider.SliderSetValue(timeParametr);
            FoodSlider.SliderSetValue(timeParametr);
            WaterSlider.SliderSetValue(timeParametr);
        }
    }
}
