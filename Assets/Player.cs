using UnityEngine;

public class Player : MonoBehaviour
{


    public int currentHealth;

    int attackMax;
    int attackMin;
    int randomAttack;
    int health;
    int criticalStrike;
    int less;


    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        attackMax = 11;
        attackMin = 5;
        currentHealth = health;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            randomAttack = Random.Range(attackMin, attackMax);
            health -= randomAttack;
            Debug.Log( "Сила удара = " + randomAttack);
            Debug.Log("Осталось здоровья = " + health);
        }
        else
        {
            Debug.Log("fuckYu");
        }

        if (health == 0)
        {

        }

    }
}
