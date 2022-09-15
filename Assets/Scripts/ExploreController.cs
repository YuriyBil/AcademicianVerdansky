using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExploreController : MonoBehaviour
{
    [SerializeField] private GameObject _radar;
    [SerializeField] private GameObject _confirm;

    [SerializeField] private Button _oneButton;
    [SerializeField] private Button _twoButton;
    [SerializeField] private Button _threeButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private Button _chairButton;
    [SerializeField] private Button _confirmYes;
    [SerializeField] private Button _confirmNo;

    public HexVerticalMinesweeper HexGame;

    public GameObject LevelText;

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
            // _exitButton.onClick.AddListener(RadarOff);
        }
        else if (level == 2)
        {
            LevelText.GetComponent<Text>().text = "Yellow level. Start?";
            _confirmYes.onClick.AddListener(OpenYellowLevel);
            _confirmNo.onClick.AddListener(RadarOn);
            //_exitButton.onClick.AddListener(RadarOff);
        }
        else if (level == 3)
        {
            LevelText.GetComponent<Text>().text = "Red level. Start?";
            _confirmYes.onClick.AddListener(OpenRedLevel);
            _confirmNo.onClick.AddListener(RadarOn);
            //_exitButton.onClick.AddListener(RadarOff);
        }
    }

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

    public void Start()
    {
        RadarOff();
    }
}
