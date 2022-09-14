using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    [SerializeField] private RenderTexture _renderTexture;
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
        ClearRenderTexture(_renderTexture);

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

    public void ClearRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture rt = RenderTexture.active;
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = rt;
    }
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
    BedRoom,
    KitchenInventory,
    Stove
}