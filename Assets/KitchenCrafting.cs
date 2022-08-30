using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class KitchenCrafting : MonoBehaviour
{
    public Button StoveOnOff;
    public Button ExitButton;
    public GameObject Stove;

    void OnEnable()
    {
        StoveOnOff.onClick.AddListener(StoveActivate);
        ExitButton.onClick.AddListener(StoveDisactivate);
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
