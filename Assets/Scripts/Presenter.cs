﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField] private Modal _Modal;

    [SerializeField] private RectTransform _Arrow;

    void Start()
    {
        _Modal.Rotate.Subscribe(x => { _Arrow.eulerAngles = new Vector3(0, 0, x); }).AddTo(this);
    }
}