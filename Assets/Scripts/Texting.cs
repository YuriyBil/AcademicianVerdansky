using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Texting : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _snowFall;
    [SerializeField] private TextMeshProUGUI _storm;
    [SerializeField] private TextMeshProUGUI _blizzard;
    [SerializeField] private TextMeshProUGUI _night;
    [SerializeField] private TextMeshProUGUI _dawn;
    [SerializeField] private TextMeshProUGUI _day;
    [SerializeField] private TextMeshProUGUI _dusk;
    [SerializeField] private TextMeshProUGUI _medNight;
    [SerializeField] private TextMeshProUGUI _medDay;
    void Start()
    {
        _snowFall.text = "SnowFall";
        _storm.text = "Storm";
        _blizzard.text = "Blizzard";
        _night.text = "Night";
        _dawn.text = "Dawn";
        _day.text = "Day";
        _dusk.text = "Dusk";
        _medNight.text = "Night";
        _medDay.text = "Day";
    }

    // void Update()
    // {

    // }
}
