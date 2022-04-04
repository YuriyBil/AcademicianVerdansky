using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player playerHealth;
    public Image imageHealth;
    private Slider slider;
    void  Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillvalue = playerHealth.currentHealth;
        slider.value = fillvalue;
    }
}
