using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{
    public static TitleScene Current { get; private set; }

    public bool IsOnButton = false;

    void Awake()
    {
        Current = this;
    }

    public void Show(bool isShow)
    {
        if (gameObject.activeSelf == isShow) { return; }
        gameObject.SetActive(isShow);
        if (isShow)
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
        IsOnButton = false;
    }
    void OnHide()
    {
        IsOnButton = false;
    }

    public void OnButton()
    {
        IsOnButton = true;
    }
}
