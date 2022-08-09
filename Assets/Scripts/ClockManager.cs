using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    void Start()
    {
        ClockReality.Instance.RunClock();
    }
}
