using UnityEngine;

public class Player : MonoBehaviour
{


    public int currentHealth;
    public int randomAttack;

    public int attackMax;
    public int attackMin;
   
    int criticalStrike;
    int less;

 
     

    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0) 
 
     
            Debug.Log("GameOver");
        }
    }

 
