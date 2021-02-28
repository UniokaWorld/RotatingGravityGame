using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine;
using UnityEngine;

public class Main : MonoBehaviour
{
    [Tooltip("GravitationalAcceleration")] [SerializeField]
    private float g = 9.8f;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 camera_center =
            new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        Vector2 mouse_pointer = new Vector2(ray.origin.x, ray.origin.y);
        Vector2 dt = mouse_pointer - camera_center;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = (rad * Mathf.Rad2Deg) + 270;
        float phase = degree * (Mathf.PI / 180);

        float xPos = g * Mathf.Cos(phase);
        float yPos = g * Mathf.Sin(phase);

        Vector3 pos = new Vector3(-yPos, xPos, 0);
        Physics.gravity = pos;
        if (Input.GetMouseButtonDown(0))
        {
            GameEventMessage.SendEvent("Click");
        }
    }

    public void StageButton(String stage)
    {
        FadeManager.Instance.LoadScene(stage, 1.0f);
    }
}