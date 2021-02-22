using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGravity : MonoBehaviour
{
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 camera_center =
            new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        Vector2 mouse_pointer = new Vector2(ray.origin.x, ray.origin.y);
        Vector2 dt = mouse_pointer - camera_center;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = (rad * Mathf.Rad2Deg) + 270;
        Debug.Log(degree);
        float phase = degree * (Mathf.PI / 180);

        float xPos = 1.8f * Mathf.Cos(phase);
        float yPos = 1.8f * Mathf.Sin(phase);

        Vector3 pos = new Vector3(-yPos, xPos, 0);
        Physics.gravity = pos;
    }
}