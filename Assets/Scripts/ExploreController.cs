using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExploreController : MonoBehaviour
{
    [SerializeField] private RectTransform _keyboard;
    [SerializeField] private RectTransform _exit;
    [SerializeField] private RectTransform _monitor;
    [SerializeField] private GameObject _radar;
    [SerializeField] private GameObject _confirm;

    // [SerializeField] private Button _yellowButton;
    // [SerializeField] private Button _redButton;
    // [SerializeField] private Button _greenButton;

    [SerializeField] private Button _oneButton;
    [SerializeField] private Button _twoButton;
    [SerializeField] private Button _threeButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private Button _chairButton;
    [SerializeField] private Button _confirmYes;
    [SerializeField] private Button _confirmNo;

    public HexVerticalMinesweeper HexGame;

    public GameObject LevelText;

    // private Vector2 _keyboardPosition;
    // private Vector2 _exitPosition;
    // private Vector2 _monitorPosition;

    public void RadarOn()
    {
        _radar.SetActive(true);
    }

    public void RadarOff()
    {
        _radar.SetActive(false);
    }

    public void ConfirmOff()
    {
        _confirm.SetActive(false);
    }

    public void ConfirmOn(int level)
    {
        _confirm.SetActive(true);
        _radar.SetActive(false);

        if (level == 1)
        {
            LevelText.GetComponent<Text>().text = "Green level. Start?";
            _confirmYes.onClick.AddListener(OpenGreenLevel);
            _confirmNo.onClick.AddListener(RadarOn);
        }
        else if (level == 2)
        {
            LevelText.GetComponent<Text>().text = "Yellow level. Start?";
            _confirmYes.onClick.AddListener(OpenYellowLevel);
            _confirmNo.onClick.AddListener(RadarOn);
        }
        else if (level == 3)
        {
            LevelText.GetComponent<Text>().text = "Red level. Start?";
            _confirmYes.onClick.AddListener(OpenRedLevel);
            _confirmNo.onClick.AddListener(RadarOn);
        }
    }

    // private void OnEnable()
    // {
    //     // _keyboardPosition = new Vector2(_keyboard.localPosition.x, _keyboard.anchoredPosition.y);
    //     // _exitPosition = new Vector2(_exit.anchoredPosition.x, _exit.anchoredPosition.y);
    //     // _monitorPosition = new Vector2(_monitor.anchoredPosition.x, _monitor.anchoredPosition.y);

    //     // _keyboard.DOAnchorPosX(_keyboard.anchoredPosition.x - 2000f, 0.01f).OnComplete(() => MoveElements());
    //     // _exit.DOAnchorPosX(_exit.anchoredPosition.x + 2000f, 0.01f);
    //     // _monitor.DOAnchorPosY(_monitor.anchoredPosition.y + 2000f, 0.01f);

    //     // _yellowButton.onClick.AddListener(OpenYellowLevel);
    //     // _redButton.onClick.AddListener(OpenRedLevel);
    //     // _greenButton.onClick.AddListener(OpenGreenLevel);

    //     //_oneButton.onClick.AddListener(ConfirmOn);
    //     //_confirmYes.onClick.AddListener(OpenGreenLevel);
    //     //_confirmNo.onClick.AddListener(ConfirmOn);

    //     //_twoButton.onClick.AddListener(OpenYellowLevel);
    //     //_threeButton.onClick.AddListener(OpenRedLevel);
    //     //_exitButton.onClick.AddListener(RadarOff);
    //     //_chairButton.onClick.AddListener(RadarOn);

    //     // _keyboard.DOAnchorPosX(_keyboard.anchoredPosition.x + 2000f, 3f);
    //     // _exit.DOAnchorPosX(_exit.anchoredPosition.x - 2000f, 3f);
    //     // _monitor.DOAnchorPosY(_monitor.anchoredPosition.y - 2000f, 3f);
    // }

    // // private void MoveElements()
    // // {
    // //     // _monitor.DOAnchorPos(_monitorPosition, 0.5f).SetEase(Ease.Linear).OnComplete(() => _radar.SetActive(true));
    // //     // _exit.DOAnchorPos(_exitPosition, 0.5f).SetEase(Ease.Linear);
    // //     // _keyboard.DOAnchorPos(_keyboardPosition, 0.5f).SetEase(Ease.Linear);
    // // }

    // // private void OnDisable()
    // // {
    // //     // _radar.SetActive(false);

    // //     // _yellowButton.onClick.RemoveListener(OpenYellowLevel);
    // //     // _redButton.onClick.RemoveListener(OpenRedLevel);
    // //     // _greenButton.onClick.RemoveListener(OpenGreenLevel);
    // //     // _oneButton.onClick.RemoveListener(OpenGreenLevel);
    // //     // _twoButton.onClick.RemoveListener(OpenYellowLevel);
    // //     // _threeButton.onClick.RemoveListener(OpenRedLevel);
    // // }

    private void OpenGreenLevel()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        SceneManager.LoadScene("GameScreen");
    }

    private void OpenYellowLevel()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        SceneManager.LoadScene("GameScreen");
    }

    private void OpenRedLevel()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        SceneManager.LoadScene("GameScreen");
    }
}
