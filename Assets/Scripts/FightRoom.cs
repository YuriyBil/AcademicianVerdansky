using System.Collections.Generic;
using UnityEngine;

public class FightRoom : MonoBehaviour
{
   public Player player1;
    public Player player2;
    List<Player> figters;
    int hero1Index;
    int hero2Index;

    void StartFight()
    {
       
        
        figters = new List<Player>();
       
        figters.Add(player1);
        figters.Add(player2);
        
        hero1Index = 0;
        hero2Index = 1;
         Hit(hero1Index, hero2Index);
        Debug.Log("Player: " + figters[hero1Index].currentHealth);
         Hit(hero2Index, hero1Index);
        Debug.Log("Enemy: " + figters[hero2Index].currentHealth);
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            Hit(hero1Index, hero2Index);
        }
    }
}
