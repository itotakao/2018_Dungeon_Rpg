using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Current { get; private set; }




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
        
    }
}
