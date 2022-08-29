using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsTexting : MonoBehaviour
{

    public TextMeshProUGUI HealthValue;
    public TextMeshProUGUI EnergyValue;
    public TextMeshProUGUI ThermoValue;
    public TextMeshProUGUI FoodValue;
    public TextMeshProUGUI WaterValue;
    public TextMeshProUGUI SuguardValue;
    public TextMeshProUGUI ProteinsValue;
    public TextMeshProUGUI FatsValue;
    public TextMeshProUGUI CarbsValue;
    public TextMeshProUGUI AttackValue;
    public TextMeshProUGUI BlockValue;
    public TextMeshProUGUI DodgeValue;
    public TextMeshProUGUI CriticalValue;


    void Start()
    {
        HealthValue.text = "100/100";
        EnergyValue.text = "100/100";
        ThermoValue.text = "100/100";
        FoodValue.text = "100/100";
        WaterValue.text = "100/100";
        SuguardValue.text = "100";
        ProteinsValue.text = "100";
        FatsValue.text = "100";
        CarbsValue.text = "100";
        AttackValue.text = "2-8";
        BlockValue.text = "7%";
        DodgeValue.text = "6%";
        CriticalValue.text = "5%";

    }

}
