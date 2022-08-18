using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Medicine : MonoBehaviour
{
    public Button MedNigtht;
    public Button MedDay;

    public GameObject NightAnimation;
    public GameObject DayAnimation;

    void OnEnable()
    {
        MedNigtht.onClick.AddListener(NightAnim);
        MedDay.onClick.AddListener(DayAnim);
    }

    void NightAnim()
    {
        DayAnimation.SetActive(false);
        NightAnimation.SetActive(true);
    }

    void DayAnim()
    {
        DayAnimation.SetActive(true);
        NightAnimation.SetActive(false);
    }

    void Update()
    {

    }
}
