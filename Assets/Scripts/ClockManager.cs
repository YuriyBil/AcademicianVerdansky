using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ClockReality.Instance.RunClock();
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}
