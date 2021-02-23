using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Modal : MonoBehaviour
{
    [SerializeField] private FloatReactiveProperty _rotate = new FloatReactiveProperty();
    [SerializeField] private StringReactiveProperty _coin = new StringReactiveProperty();
    [SerializeField] private int _NeedCoin;
    [SerializeField] private IntReactiveProperty _nowCoin = new IntReactiveProperty();

    public IReadOnlyReactiveProperty<float> Rotate => _rotate;
    public IReadOnlyReactiveProperty<string> Coin => _coin;

    [Tooltip("GravitationalAcceleration")] [SerializeField]
    private float g = 9.8f;

    void Update()
    {
        if (true)
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
    }

    void GetCoin()
    {
        _coin.Value = "coin" + _nowCoin + _NeedCoin;
    }
}