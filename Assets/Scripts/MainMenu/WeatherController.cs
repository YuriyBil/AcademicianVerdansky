using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Image))]
public class WeatherController : MonoBehaviour
{
    public GameObject Snow;

    void KeyCodeInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Snow.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.X))
        {
            Snow.SetActive(false);
        }
    }

    void Update()
    {
        KeyCodeInput();
    }
}
