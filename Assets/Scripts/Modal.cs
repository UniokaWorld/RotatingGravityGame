﻿using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine;
using UnityEngine;
using UniRx;

public class Modal : MonoBehaviour
{
    [SerializeField] private FloatReactiveProperty _rotate = new FloatReactiveProperty();
    [SerializeField] private StringReactiveProperty _coin = new StringReactiveProperty();
    [SerializeField] private int _NeedCoin;
    [SerializeField] IntReactiveProperty _nowCoin = new IntReactiveProperty();
    [SerializeField] BoolReactiveProperty _p_start = new BoolReactiveProperty(false);
    [SerializeField] BoolReactiveProperty _can_goal = new BoolReactiveProperty(false);
    [SerializeField] BoolReactiveProperty _goal = new BoolReactiveProperty(false);

    public IReadOnlyReactiveProperty<float> Rotate => _rotate;
    public IReadOnlyReactiveProperty<string> Coin => _coin;
    public ReactiveProperty<int> NowCoin => _nowCoin;
    public IReadOnlyReactiveProperty<bool> P_Start => _p_start;
    public ReactiveProperty<bool> Can_Goal => _can_goal;
    public ReactiveProperty<bool> Goal => _goal;

    [Tooltip("GravitationalAcceleration")] [SerializeField]
    private float g = 9.8f;

    void Start()
    {
        Physics.gravity = new Vector3(0, 0, 0);
        if (_NeedCoin == 0) _can_goal.Value = true;
        if (!_can_goal.Value)
            NowCoin.Subscribe(x =>
            {
                _coin.Value = "Coin" + _nowCoin + "/" + _NeedCoin;
                if (_nowCoin.Value == _NeedCoin) _can_goal.Value = true;
            }).AddTo(this);
        Goal.Where(x => x).Subscribe(_ =>
        {
            GameEventMessage.SendEvent("GameClear");
            Physics.gravity = new Vector3(0, 0, 0);
        });
    }

    void Update()
    {
        if (_p_start.Value)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 camera_center = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            Vector2 mouse_pointer = new Vector2(ray.origin.x, ray.origin.y);
            Vector2 dt = mouse_pointer - camera_center;
            float rad = Mathf.Atan2(dt.y, dt.x);
            float degree = (rad * Mathf.Rad2Deg) + 270;
            _rotate.Value = degree;
            float phase = degree * (Mathf.PI / 180);

            float xPos = g * Mathf.Cos(phase);
            float yPos = g * Mathf.Sin(phase);

            Vector3 pos = new Vector3(-yPos, xPos, 0);
            Physics.gravity = pos;
        }

        else
        {
            if (Input.GetMouseButtonDown(0)) _p_start.Value = true;
        }
    }
}