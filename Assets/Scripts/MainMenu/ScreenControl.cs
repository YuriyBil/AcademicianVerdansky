using UnityEngine;
using UnityEngine.Video;

public class ScreenControl : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private VideoPlayer _videoPlayer;

    public GameState GetGameState()
    {
        return _gameState;
    }

    public VideoPlayer GetVideoPlayer()
    {
        if (_videoPlayer == null)
        {
            return null;
        }
        return _videoPlayer;
    }
}
