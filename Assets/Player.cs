using UnityEngine;

public class Player : MonoBehaviour
{


    public int currentHealth;
    public int randomAttack;

    public int attackMax;
    public int attackMin;
    int health;
    int criticalStrike;
    int less;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        attackMax = 10;
        attackMin = 1;

    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.A))
         {
             
             health -= randomAttack;
             Debug.Log( "Сила удара = " + randomAttack);
             Debug.Log("Осталось здоровья = " + health);
         } */

        if (health <= 0)
        {
            Debug.Log("GameOver");
        }
    }

}
