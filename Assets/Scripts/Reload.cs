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
            .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(0.5f)))
            .TakeUntil(mouseUpStream)
            .RepeatUntilDestroy(this.gameObject)
            .Subscribe(_ => { ReloadScene(); });
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetScene(String stage)
    {
        FadeManager.Instance.LoadScene(stage, 1.0f);
    }
}