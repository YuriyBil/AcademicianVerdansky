using System.Collections.Generic;

using UnityEngine;

public class FightRoom : MonoBehaviour
{
    [SerializeField] HexVerticalMinesweeper hexVertical;
    [SerializeField] NewGame newGame;
    [SerializeField] TestSaveGame testSave;
    public Player Player;
    public Player Enemy;
    List<Player> figters;
    int hero1Index;
    int hero2Index;
   

    public void Start()
    {
        EnemyCreate();
        figters = new List<Player>();
        figters.Add(Player);
        figters.Add(Enemy);
        hero1Index = 0;
        hero2Index = 1;

    }

    public void Round()
    {
        Hit(hero1Index, hero2Index);
        Debug.Log("Player: " + figters[hero1Index].currentHealth);

        Hit(hero2Index, hero1Index);
        Debug.Log("Enemy: " + figters[hero2Index].currentHealth);


        if (figters[hero1Index].currentHealth <= 0)
        {
            Debug.Log("Lose"); 
            Debug.Log("Objects " + figters.Count);
             
        }
        if (figters[hero2Index].currentHealth <= 0)
        {
            Debug.Log("Win"); 
            Debug.Log("Objects " + figters.Count);
            hexVertical.HidenFight();
        }

    }

    public void Hit(int hero1Index, int hero2Index)
    {
        figters[hero2Index].randomAttack = Random.Range(figters[hero2Index].attackMin, figters[hero2Index].attackMax + 1);
        figters[hero1Index].currentHealth -= figters[hero2Index].randomAttack;


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Start();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Round();
        }



    }
    public void EnemyCreate()
    {
        int randomMonster = Random.Range(1, 4 + 1);
        if (randomMonster == 1)
        {
            CreateMonster1();
        }
        if (randomMonster == 2)
        {
            CreateMonster2();
        }
        if (randomMonster == 3)
        {
            CreateMonster3();
        }
        if (randomMonster == 4)
        {
            CreateMonster4();
        }
    }

    private void CreateMonster4()
    {
        Enemy.currentHealth = 25;
        Enemy.maxHealth = 25;
        Enemy.attackMax = 8;
        Enemy.attackMin = 1;
    }

    private void CreateMonster3()
    {
        Enemy.currentHealth = 20;
        Enemy.maxHealth = 20;
        Enemy.attackMax = 7;
        Enemy.attackMin = 1;
    }

    private void CreateMonster2()
    {
        Enemy.currentHealth = 15;
        Enemy.maxHealth = 15;
        Enemy.attackMax = 6;
        Enemy.attackMin = 1;
    }

    public void CreateMonster1()
    {
        Enemy.currentHealth = 10;
        Enemy.maxHealth = 10;
        Enemy.attackMax = 5;
        Enemy.attackMin = 1;
    }
}
