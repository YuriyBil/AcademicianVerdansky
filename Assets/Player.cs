using UnityEngine;

public class Player : MonoBehaviour
{


    public int currentHealth;
    public int randomAttack;

    public int attackMax;
    public int attackMin;
   
    int criticalStrike;
    int less;

<<<<<<< Updated upstream
     

    // Update is called once per frame
    void Update()
    { 

        if (currentHealth <= 0)
=======
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            health -= 1;
         
            Debug.Log(health);
        }
        else
>>>>>>> Stashed changes
        {
            Debug.Log("GameOver");
        }
    }

}
