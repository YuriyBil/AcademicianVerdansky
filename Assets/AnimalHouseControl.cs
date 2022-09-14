using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class AnimalHouseControl : MonoBehaviour
{
    public VideoPlayer Vid;
    public VideoClip Animal2;
    void Start()
    {
        Vid.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        //Debug.Log("Video Is Over");
        Vid.clip = Animal2;
        Vid.isLooping = true;
        Vid.Play();
    }
}
