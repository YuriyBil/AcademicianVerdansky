using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TextScreenController : MonoBehaviour
{
    public string _textUA;

    public string _textRUS;

    [SerializeField] private TextMeshProUGUI ScreenText;
    [SerializeField] private ScrollRect _scrollRect;
    private int CharacterNumber;

    private void Start()
    {
        CharacterNumber = 1;
        StartCoroutine(AddCharacter());
    }

    private IEnumerator AddCharacter()
    {
        while (CharacterNumber < _textUA.Length)
        {
            yield return new WaitForSeconds(0.1f);

            ScreenText.text = _textUA.Substring(0, CharacterNumber);
            CharacterNumber++;
            Canvas.ForceUpdateCanvases();
            _scrollRect.verticalNormalizedPosition = 0f;
        }
    }
}