using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGravity : MonoBehaviour
{
    Plane plane = new Plane();
    float distance = 0;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var lookPoint = ray.GetPoint(distance);
        transform.LookAt(transform.localPosition + Vector3.forward, lookPoint);
        float phase = transform.eulerAngles.z * (Mathf.PI / 180);

        float xPos = 1.8f * Mathf.Cos(phase);
        float yPos = 1.8f * Mathf.Sin(phase);

        Vector3 pos = new Vector3(-yPos, xPos, 0);
        Physics.gravity = pos;
    }
}