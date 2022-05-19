using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    [SerializeField] private GameState _gameState;

    public GameState GetGameState()
    {
        return _gameState;
    }
}
