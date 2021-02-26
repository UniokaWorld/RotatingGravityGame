using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    void Start()
    {
        var mouseDownStream = this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.R));
        var mouseUpStream = this.UpdateAsObservable().Where(_ => Input.GetKeyUp(KeyCode.R));

        //長押しの判定
        mouseDownStream
            //マウスクリックされたら3秒後にOnNextを流す
            .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(1)))
            //途中でMouseUpされたらストリームをリセット
            .TakeUntil(mouseUpStream)
            .RepeatUntilDestroy(this.gameObject)
            .Subscribe(_ => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }
}