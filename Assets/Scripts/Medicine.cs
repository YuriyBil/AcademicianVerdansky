using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class Medicine : MonoBehaviour
{
    public Button MedNigthtButton;
    public Button MedDayButton;

    public Button Profile;
    public Button ExitProfile;

    //public VideoPlayer Night;
    public VideoPlayer Day;
    public VideoClip MedDay;
    public VideoClip MedNight;

    public GameObject ProfileOfPlayer;

    void OnEnable()
    {
        MedNigthtButton.onClick.AddListener(NightAnim);
        MedDayButton.onClick.AddListener(DayAnim);
        Profile.onClick.AddListener(ShowProfile);
        ExitProfile.onClick.AddListener(CancelShowProfile);
    }

    void NightAnim()
    {
        Day.Stop();
        Day.clip = MedNight;
        Day.Play();
    }

    void DayAnim()
    {
        Day.Stop();
        Day.clip = MedDay;
        Day.Play();
    }

    void ShowProfile()
    {
        ProfileOfPlayer.SetActive(true);
        // Day.Stop();
        // Night.Stop();
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
