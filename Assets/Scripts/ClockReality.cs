using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ClockReality : MonoBehaviour
{
    private float _secondsNew = 60f, _minutesNew = 60f, _hoursNew = 12f;
    private int _interval = 1;
    private float _nextTime = 1;

    [SerializeField]
    private Text _seconds;
    [SerializeField]
    private Text _minutes;
    [SerializeField]
    private Text _hours;

    private Text _days;

    private DateTime _time = DateTime.Now;
    private DateTime _timeStart = DateTime.Now;
    private bool _isClockRunning = false; // to activate ClockReality.Instance.RunClock();

    public Button TimeNow;
    public Button TimeDay;

    public Button TimeDelta;

    public Dropdown Changing;

    public Sprite Day;
    public Sprite Night;

    public GameObject Panel;

    public static ClockReality Instance; // Object instance


    void Start()
    {
        DateTime currentDate = DateTime.Now;

        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString", DateTime.Now.ToBinary().ToString()));

        DateTime oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);

        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);

        PlayerPrefs.SetString("sysString", currentDate.ToBinary().ToString());

        Changing.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(Changing);
        });
    }

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

    public void DropdownValueChanged(Dropdown change)
    {
        int[] min = new int[] { -4320, -2880, -1440, 1440, 2880, 4320, -30, -20, -10, 10, 20, 30 };
        PlusMinutes(min[change.value]);
    }

    public void PressTimeNow()
    {
        print(_time.Hour + " :" + _time.Minute + " :" + _time.Second);
    }

    public void ChangeBG()
    {
        if (_time.Hour >= 5 && _time.Hour <= 19)
        {
            Panel.GetComponent<Image>().sprite = Day;
            TimeNow.GetComponent<Image>().color = new Color(0, 0, 0);
            TimeDay.GetComponent<Image>().color = new Color(0, 0, 0);
            TimeDelta.GetComponent<Image>().color = new Color(0, 0, 0);
            Changing.GetComponent<Image>().color = new Color(0, 0, 0);
        }
        else
        {
            Panel.GetComponent<Image>().sprite = Night;
        }
    }

    public void PressTimesDay()
    {
        if (_time.Hour >= 5 && _time.Hour <= 10)
        {
            print("Morning");
        }
        else if (_time.Hour > 10 && _time.Hour <= 19)
        {
            print("Day");
        }
        else
        {
            print("Night");
        }
    }

    public void DeltaTime()
    {
        TimeSpan delta = DateTime.Now.Subtract(_timeStart);
        double _days = Math.Floor(delta.TotalDays);
        double _minutes = Math.Floor(delta.TotalMinutes);
        double _seconds = Math.Floor(delta.TotalSeconds);

        print(_days + " Days " + _minutes + " Minutes " + _seconds + " Seconds ");
    }

    public void PlusMinutes(int count)
    {
        _time = _time.AddMinutes(count);
        UpdateClock();
    }

    void UpdateClock()
    {
        _seconds.text = ("" + (_time.Second * (60f / _secondsNew))).PadLeft(2, '0');
        _minutes.text = ("" + (_time.Minute * (60f / _minutesNew))).PadLeft(2, '0') + " :";
        _hours.text = ("" + (_time.Hour * (12f / _hoursNew))).PadLeft(2, '0') + " :";
    }

    void Update()
    {
        if (_isClockRunning && Time.time >= _nextTime)
        {
            _time = _time.AddSeconds(1);
            UpdateClock();
            ChangeBG();
            _nextTime += _interval;
        }

    }

    public void RunClock()
    {
        _isClockRunning = true;
    }

}

