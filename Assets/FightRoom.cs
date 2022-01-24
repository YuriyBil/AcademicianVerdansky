using System.Collections.Generic;
using UnityEngine;

public class FightRoom : MonoBehaviour
{
    Player player1;
    Player player2;
    List<Player> figters;
    int hero1Index;
    int hero2Index;

    void StartFight()
    {
        player1 = GameObject.Player();
        player2 = new Player();
        figters = new List<Player>();
        figters.Add(player1);
        figters.Add(player2);
        hero1Index = 0;
        hero2Index = 1;
        Hit(hero1Index, hero2Index);
        Debug.Log("1st: " + figters[hero1Index].currentHealth);
        Hit(hero2Index, hero1Index);
        Debug.Log("2st: " + figters[hero2Index].currentHealth);
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
            StartFight();
        }
    }
}
