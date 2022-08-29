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

    public Button Profile;
    public Button ExitProfile;

    public GameObject NightAnimation;
    public GameObject DayAnimation;

    public GameObject ProfileOfPlayer;

    void OnEnable()
    {
        MedNigtht.onClick.AddListener(NightAnim);
        MedDay.onClick.AddListener(DayAnim);
        Profile.onClick.AddListener(ShowProfile);
        ExitProfile.onClick.AddListener(CancelShowProfile);
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

    void ShowProfile()
    {
        ProfileOfPlayer.SetActive(true);
        DayAnimation.SetActive(false);
        NightAnimation.SetActive(false);
    }

    void CancelShowProfile()
    {
        ProfileOfPlayer.SetActive(false);
        DayAnim();
    }

    void Update()
    {

    }
}
