using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{

    public static TitleUI Current { get; private set; }

    public bool IsOnButton = false;

    void Awake()
    {
        Current = this;
    }

    public void Show(bool show){
        if (gameObject.activeSelf == show) { return; }
        gameObject.SetActive(show);

        if(show){
            OnShow();
        }else{
            OnHide();
        }
    }

    void OnShow(){
        IsOnButton = false;
    }
    void OnHide(){
        IsOnButton = false;
    }

    public void OnButton()
    {
        IsOnButton = true;
    }
}
