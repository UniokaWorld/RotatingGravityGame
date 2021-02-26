using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Modal _Modal;

    // Start is called before the first frame update
    void Start()
    {
        var onTriggerEnterPlayer = this.OnTriggerEnterAsObservable()
            .Select(collision => collision.tag)
            .Where(tag => tag == "Goal");
        // GameControllerの獲得リストに自身を追加
        onTriggerEnterPlayer.Select(_ => _Modal).Where(x => x.Can_Goal.Value == true)
            .Subscribe(x => x.Goal.Value = true);
    }
}