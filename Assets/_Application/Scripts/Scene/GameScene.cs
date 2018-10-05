using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public static GameScene Current { get; private set; }

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
