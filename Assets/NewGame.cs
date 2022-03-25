using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    [SerializeField]
    Player player;

    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
    public void StartNewGame()
    {
        player.currentHealth = 2313;
        player.attackMax = 10;
        player.attackMin = 1;
        SaveSystem.SetInt("currentHealth", player.currentHealth);
        SaveSystem.SetInt("attackMax", player.attackMax);
        SaveSystem.SetInt("attackMin", player.attackMin);
        Debug.Log($"{player.currentHealth}" + " " + $"{player.attackMax}" + " " + $"{player.attackMin}");
        SceneManager.LoadScene(1);


    }
    public void Expedition()
    { 
        SceneManager.LoadScene(2); 
    }

}
