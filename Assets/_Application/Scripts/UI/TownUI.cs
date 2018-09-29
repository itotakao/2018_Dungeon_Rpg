using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownUI : MonoBehaviour {

    public static TownUI Current { get; private set; }

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

    }

    void OnHide()
    {

    }
}
