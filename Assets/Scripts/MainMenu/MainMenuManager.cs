using System;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    [SerializeField] private RenderTexture _renderTexture;
    [SerializeField] private GameObject _clouds;
    [SerializeField] private List<ScreenControl> ListScreen;

    private Action _endActivateLoadingScreen;
    private Action _endDeActivateLoadingScreen;
    private GameState _currentGameState;
    private bool isСheckTexture;

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

    private void OnEnable()
    {
        _endActivateLoadingScreen += OpenAdjustedScreen;
    }

    private void OnDisable()
    {
        _endActivateLoadingScreen -= OpenAdjustedScreen;
    }

    public void OpenScreen(GameState gameState)
    {
        _currentGameState = gameState;

        LoadingScreenManager.Instance.ActivateLoadingScreen(_endActivateLoadingScreen);
    }

    private void OpenAdjustedScreen()
    {
        ClearRenderTexture(_renderTexture);

        foreach (ScreenControl go in ListScreen)
        {
            if (go.GetGameState() == _currentGameState)
            {
                go.gameObject.SetActive(true);
            }
            else go.gameObject.SetActive(false);
        }

        if (_currentGameState == GameState.MainMenu)
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

        isСheckTexture = true;
    }

    public void Update()
    {
        if (isСheckTexture)
        {
            СheckTextureIsCreated();
        }
    }

    private void СheckTextureIsCreated()
    {
        if (_renderTexture.IsCreated())
        {
            isСheckTexture = false;
            LoadingScreenManager.Instance.DeActivateLoadingScreen(_endDeActivateLoadingScreen);
        }
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