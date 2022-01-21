using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Player player;    

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
