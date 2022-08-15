using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Image))]
public class WeatherController : MonoBehaviour
{
    public float Speed = 1f;
    public int FrameRate = 30;
    public bool Loop = false;
    public Image _snowImage = null;

    private Sprite[] _snowSprites = null;
    private float _snowTimePerFrame = 0f;
    private float _snowElapsedTime = 0f;
    private int _snowCurrentFrame = 0;

    void Start()
    {
        enabled = false;
        LoadSpriteSheet();
    }

    private void LoadSpriteSheet()
    {
        _snowSprites = Resources.LoadAll<Sprite>("snow-Sheet1");
        if (_snowSprites != null && _snowSprites.Length > 0)
        {
            _snowTimePerFrame = 1f / FrameRate;
            Play();
        }
        else
        {
            Debug.LogError("Failed to load sprite sheet");
        }
    }

    public void Play()
    {
        enabled = true;
    }

    public void Update()
    {
        _snowElapsedTime += Time.deltaTime * Speed;
        if (_snowElapsedTime >= _snowTimePerFrame)
        {
            _snowElapsedTime = 0f;
            ++_snowCurrentFrame;
            SetSprite();
            if (_snowCurrentFrame >= _snowSprites.Length)
            {
                if (Loop)
                {
                    _snowCurrentFrame = 0;
                }
                else
                {
                    enabled = false;
                }
            }
        }
    }

    private void SetSprite()
    {
        if (_snowCurrentFrame >= 0 && _snowCurrentFrame < _snowSprites.Length)
        {
            _snowImage.sprite = _snowSprites[_snowCurrentFrame];
        }
    }
}
