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
    [SerializeField] private Button _snow;
    //public Color tintColor;
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

        // TextMeshPro _snow   = GetComponent<TextMeshPro>();
        //_snowFall.color = new Color32(255, 128, 0, 255);

        var colors = _snow.GetComponent<Button>().colors;
        colors.normalColor = Color.red;
        _snow.GetComponent<Button>().colors = colors;
        //_snow.colors = colors;

        //_snow.color = new Color32(255, 128, 0, 255);
    }

    // void Update()
    // {

    // }
}
