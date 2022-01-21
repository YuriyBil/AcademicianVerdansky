using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public int currentHealth;
    
    int health;


    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            health -= 1;
            currentHealth = health;
            Debug.Log(health);
        }
        else
        {
            Debug.Log("fuckYu");
        }

    }
}
