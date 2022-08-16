using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherController : MonoBehaviour
{
    public GameObject SnowFall;
    public GameObject Storm;
    public GameObject Blizzard;

    public bool isActive = false;

    void KeyCodeInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isActive = !isActive;
            SnowFall.SetActive(isActive);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            isActive = !isActive;
            Storm.SetActive(isActive);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            isActive = !isActive;
            Blizzard.SetActive(isActive);
        }
    }

    void Update()
    {
        KeyCodeInput();
    }
}
