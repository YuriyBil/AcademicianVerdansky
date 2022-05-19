using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RadarConrroller : MonoBehaviour
{
    [SerializeField] Transform _parent;
    private Sequence _mySequence;
    // private Guid uid;
    private void OnEnable()
    {
        _mySequence = DOTween.Sequence();

        _mySequence.Append(_parent.DORotate(new Vector3(0, 0, -360), 5f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        _mySequence.OnComplete(() => _mySequence.Restart());

        // uid = System.Guid.NewGuid();
        // _mySequence.id = uid;
    }

    private void OnDisable()
    {

        _mySequence.Complete();

        _mySequence.Kill();

        DOTween.Kill(_mySequence);
        // DOTween.KillAll(true);
        // _parent.DOKill();


        _mySequence = null;
    }
}
