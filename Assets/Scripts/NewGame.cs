 
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class NewGame : MonoBehaviour
{
    [SerializeField] TestSaveGame testSave;
    [SerializeField] Player player;
    [SerializeField] Player Enemy;
    

    public void Continue() 
    { 
        player.currentHealth = SaveSystem.GetInt("currentHealth");
        player.attackMax = SaveSystem.GetInt("attackMax");
        player.attackMin = SaveSystem.GetInt("attackMin");
        player.maxHealth = SaveSystem.GetInt("maxHealth");
        Debug.Log($"{player.currentHealth}" + " " + $"{player.attackMax}" + " " + $"{player.attackMin}");
        SceneManager.LoadScene(1); 
    }
    public void StartNewGame()
    {
        player.currentHealth = 100;
        player.maxHealth = 100;
        player.attackMax = 10;
        player.attackMin = 1;
        
        SaveSystem.SetInt("currentHealth", player.currentHealth);
        SaveSystem.SetInt("maxHealth", player.maxHealth);
        SaveSystem.SetInt("attackMax", player.attackMax);
        SaveSystem.SetInt("attackMin", player.attackMin);
        Debug.Log($"{player.currentHealth}" + " " + $"{player.attackMax}" + " " + $"{player.attackMin}");
        SceneManager.LoadScene(1);


    }
    public void Expedition()
    { 
        
        SaveSystem.SetInt("currentHealth", player.currentHealth);
        SaveSystem.SetInt("maxHealth", player.maxHealth);
        SaveSystem.SetInt("attackMax", player.attackMax);
        SaveSystem.SetInt("attackMin", player.attackMin);
        SceneManager.LoadScene(2);
    }

  
}
