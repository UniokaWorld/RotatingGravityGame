using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField] private RotateModal _Modal;

    [SerializeField] private RectTransform _Arrow;

    void Start()
    {
        _Modal.Rotate.Subscribe(x => { _Arrow.Rotate(new Vector3(0, 0, x)); }).AddTo(this);
    }
}