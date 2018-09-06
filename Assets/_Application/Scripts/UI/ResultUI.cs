using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour {

    public static ResultUI Current { get; private set; }

    public bool IsRestart = false;
    public bool IsExit = false;

    void Awake()
    {
        Current = this;
    }

    public void Show(bool show)
    {
        if (gameObject.activeSelf == show) { return; }
        gameObject.SetActive(show);

        if (show)
        {
            OnShow();
        }
        else
        {
            OnHide();
        }
    }

    void OnShow()
    {

    }
    void OnHide()
    {
        IsRestart = false;
        IsExit = false;
    }

    public void OnRestartButton()
    {
        IsRestart = true;
    }

    public void OnExitButton()
    {
        IsExit = true;
    }

}
