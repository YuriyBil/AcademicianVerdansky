using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetPanelManager : MonoBehaviour
{
    [SerializeField]
    public Slider _healthPet;

    [SerializeField]
    public Slider _energyPet;

    public SliderPanelsController HelthPetSlider;
    public SliderPanelsController EnergyPetSlider;


    private int _hpPet = 100;
    private float _dValuePet = 10f;
    private bool _isTime = false;
    private string _timeDirection;


    public static PetPanelManager Instance; // Object instance

    void Awake()
    {
        // Checking for the existence of an instance
        if (Instance == null)
        { // Іnstance is exists
            Instance = this; // Set a reference to an object instance
        }
        else if (Instance == this)
        { // An object instance already exists in the scene
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }





    void Start()
    {
        HelthPetSlider = new SliderPanelsController(_healthPet, _hpPet);
        EnergyPetSlider = new SliderPanelsController(_energyPet, _hpPet);
    }

    void KeyCodeInput()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            HelthPetSlider.SliderSetValue(-_dValuePet);
            EnergyPetSlider.SliderSetValue(-_dValuePet);
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            HelthPetSlider.SliderSetValue(_dValuePet);
            EnergyPetSlider.SliderSetValue(_dValuePet);
        }

        else if (Input.GetKeyDown(KeyCode.F))
        {
            _isTime = !_isTime;
            _timeDirection = "down";
        }

        else if (Input.GetKeyDown(KeyCode.R))
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
            HelthPetSlider.SliderSetValue(timeParametr);
            EnergyPetSlider.SliderSetValue(timeParametr);
        }
    }
}
