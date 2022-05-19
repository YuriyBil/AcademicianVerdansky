using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameState _gameState;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("11111");
        MainMenuManager.Instance.OpenScreen(_gameState);
    }
}
