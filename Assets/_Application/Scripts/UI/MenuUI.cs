using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public static MenuUI Current { get; private set; }

    public bool IsOnButton;

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
        IsOnButton = false;
    }
    void OnHide()
    {
    }

    public void OnButton(){
        IsOnButton = true;
    }
}
