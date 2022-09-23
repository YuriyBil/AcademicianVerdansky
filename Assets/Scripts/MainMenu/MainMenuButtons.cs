using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameState _gameState;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("1");
        MainMenuManager.Instance.OpenScreen(_gameState);
        WeatherController.Instance.CancelWeather();
    }


    void Update()
    {
        SliderPanelsManager.Instance.HelthPersSlider.SliderSetValue(-Time.deltaTime);
        SliderPanelsManager.Instance.EnergyPersSlider.SliderSetValue(-0.05f);
        SliderPanelsManager.Instance.TemperatureSlider.SliderSetValue(-0.05f);
        SliderPanelsManager.Instance.FoodSlider.SliderSetValue(-0.05f);
        SliderPanelsManager.Instance.WaterSlider.SliderSetValue(-0.05f);

        PetPanelManager.Instance.HelthPetSlider.SliderSetValue(-Time.deltaTime);
        PetPanelManager.Instance.EnergyPetSlider.SliderSetValue(-0.05f);
    }
}
