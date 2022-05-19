using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    [SerializeField] private List<RectTransform> ListСlouds;
    [SerializeField] private float _speed;
    private void OnEnable()
    {
        // Debug.Log(speed);
        // var speed = (1700f - ListСlouds[0].localPosition.x) / 20;
        // Debug.Log(speed);

        foreach (RectTransform go in ListСlouds)
        {
            var x = Random.Range(0, 1700f);
            var y = Random.Range(500, 970f);

            go.localPosition = new Vector3(x, y, 0);

            var _delta = 1700f - go.localPosition.x;

            go.DOAnchorPosX(1700f, _delta / _speed).SetEase(Ease.Linear).OnComplete(() => SetPath(go));
        }
    }

    private void SetPath(RectTransform go)
    {
        go.localPosition = new Vector3(0, go.localPosition.y, 0);
        go.DOAnchorPosX(1700f, 1700 / _speed).SetEase(Ease.Linear).OnComplete(() => SetPath(go));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
