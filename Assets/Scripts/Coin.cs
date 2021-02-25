﻿using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        // Playerと衝突した時
        var onTriggerEnterPlayer = this.OnTriggerEnterAsObservable()
            .Select(collision => collision.tag)
            .Where(tag => tag == "Player");
        // GameControllerの獲得リストに自身を追加
        onTriggerEnterPlayer
            .Select(_ => GameObject.FindObjectOfType<Modal>())
            .Subscribe(x => x.NowCoin.Value++);
        // 自身をDestroy
        onTriggerEnterPlayer
            .Subscribe(_ => Destroy(gameObject));
    }
}