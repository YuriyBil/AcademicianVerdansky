using UnityEngine;

public class TestSaveGame : MonoBehaviour
{
    //INT (UI)
    [Header("Save int")] 
    [SerializeField]
    Player player; 

    // Use this for initialization
    private void Start()
    { 
        //Load Save int 
        player.currentHealth = SaveSystem.GetInt("currentHealth");
        player.attackMax = SaveSystem.GetInt("attackMax");
        player.attackMin = SaveSystem.GetInt("attackMin");
        player.maxHealth = SaveSystem.GetInt("maxHealth");
    }

    //Save "NEXT"
    private void OnApplicationQuit()
    {
        SaveSystem.SetInt("currentHealth", player.currentHealth);
        SaveSystem.SetInt("attackMax", player.attackMax);
        SaveSystem.SetInt("attackMin", player.attackMin);
        SaveSystem.SetInt("maxHealth", player.maxHealth);
    }

    //Save "NEXT"
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        { 
            SaveSystem.SetInt("currentHealth", player.currentHealth);
            SaveSystem.SetInt("attackMax", player.attackMax);
            SaveSystem.SetInt("attackMin", player.attackMin);
            SaveSystem.SetInt("maxHealth", player.maxHealth);
        }
    } 
}
