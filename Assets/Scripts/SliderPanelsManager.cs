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

    private SliderPanelsController _helthPersSlider;
    private SliderPanelsController _energyPersSlider;
    private SliderPanelsController _temperatureSlider;
    private SliderPanelsController _foodSlider;
    private SliderPanelsController _waterSlider;

    private int _hp = 100;
    private float _dValue = 10f;
    private bool _isTime = false;
    private string _timeDirection;


    public static SliderPanelsManager instance = null; // Object instance

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





    void Start()
    {
        _helthPersSlider = new SliderPanelsController(_healthPers, _hp);
        _energyPersSlider = new SliderPanelsController(_energyPers, _hp);
        _temperatureSlider = new SliderPanelsController(_temperature, _hp);
        _foodSlider = new SliderPanelsController(_food, _hp);
        _waterSlider = new SliderPanelsController(_water, _hp);
    }

    void KeyCodeInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _helthPersSlider.SliderSetValue(-_dValue);
            _energyPersSlider.SliderSetValue(-_dValue);
            _temperatureSlider.SliderSetValue(-_dValue);
            _foodSlider.SliderSetValue(-_dValue);
            _waterSlider.SliderSetValue(-_dValue);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            _helthPersSlider.SliderSetValue(_dValue);
            _energyPersSlider.SliderSetValue(_dValue);
            _temperatureSlider.SliderSetValue(_dValue);
            _foodSlider.SliderSetValue(_dValue);
            _waterSlider.SliderSetValue(_dValue);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            _isTime = !_isTime;
            _timeDirection = "up";
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            _isTime = !_isTime;
            _timeDirection = "down";
        }
    }

    void Update()
    {
        KeyCodeInput();

        if (_isTime)
        {
            float timeParametr = Time.deltaTime * 10;
            if (_timeDirection == "up")
            {
                timeParametr = -timeParametr;
            }
            _helthPersSlider.SliderSetValue(timeParametr);
            _energyPersSlider.SliderSetValue(timeParametr);
            _temperatureSlider.SliderSetValue(timeParametr);
            _foodSlider.SliderSetValue(timeParametr);
            _waterSlider.SliderSetValue(timeParametr);
        }
    }
}
