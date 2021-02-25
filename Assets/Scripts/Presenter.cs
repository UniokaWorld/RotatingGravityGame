using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField] private Modal _Modal;
    [SerializeField] private RectTransform _Arrow;
    [SerializeField] private TextMeshProUGUI coinUI;
    [SerializeField] private GameObject Messege;

    void Start()
    {
        _Modal.Rotate.Subscribe(x => { _Arrow.eulerAngles = new Vector3(0, 0, x); }).AddTo(this);
        _Modal.Coin.Subscribe(x => coinUI.text = x).AddTo(this);
        _Modal.P_Start.Subscribe(x => Messege.SetActive(!x));
    }
}