using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    [SerializeField] private GameObject Laboratory;
    [SerializeField] private GameObject PetShelter;
    [SerializeField] private GameObject Hospital;
    [SerializeField] private GameObject ResourceBase;
    [SerializeField] private GameObject GameWorld;
    [SerializeField] private GameObject _clouds;
    [SerializeField] private List<ScreenControl> ListScreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (PlayerPrefs.HasKey("FirstStart"))
        {
            OpenScreen(GameState.MainMenu);
            PlayerPrefs.DeleteKey("FirstStart");
        }
    }

    public void OpenScreen(GameState _gameState)
    {
        foreach (ScreenControl go in ListScreen)
        {
            if (go.GetGameState() == _gameState)
            {
                go.gameObject.SetActive(true);
            }
            else go.gameObject.SetActive(false);
        }

        if (_gameState == GameState.MainMenu)
        {
            _clouds.SetActive(true);
        }
        else _clouds.SetActive(false);
    }

    // public void SaveInventory()
    // {
    //      SaveSystemManager.Save(0);
    // }

    // public void LoadInventory()
    // {
    //     SaveSystemManager.Load(0);
    // }
}

public enum GameState
{
    Laboratory,
    PetShelter,
    Hospital,
    ResourceBase,
    GameWorld,
    MainMenu,
    Radar,
    FirstScreen,
    HistoryScreen,
    Corridor,
    Kitchen,
    BedRoom
}