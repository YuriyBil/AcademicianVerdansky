using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance;
    [SerializeField] private Image Image;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ActivateLoadingScreen(Action endActivate)
    {
        Image.raycastTarget = true;
        Image.DOFade(1, 0.5f).OnComplete(() => EndActivate(endActivate));
    }

    private void EndActivate(Action endActivate)
    {
        endActivate.Invoke();
    }

    public void DeActivateLoadingScreen(Action endDeActivate)
    {
        Image.DOFade(0, 0.5f).OnComplete(() => EndDeActivate(endDeActivate));
    }

    private void EndDeActivate(Action endDeActivate)
    {
        Image.raycastTarget = false;
        endDeActivate.Invoke();
    }
}
