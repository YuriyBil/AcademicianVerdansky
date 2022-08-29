using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class KitchenCrafting : MonoBehaviour
{
    public Button StoveOnOff;
    public Button TumblerButton;
    public GameObject Stove;

    void OnEnable()
    {
        StoveOnOff.onClick.AddListener(StoveActivate);
        TumblerButton.onClick.AddListener(StoveDisactivate);
    }

    void StoveActivate()
    {
        Stove.SetActive(true);
    }

    void StoveDisactivate()
    {
        Stove.SetActive(false);
    }

}
