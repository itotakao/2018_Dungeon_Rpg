using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class Touch : MonoBehaviour
{

    [SerializeField]
    private UnityEngine.Events.UnityEvent m_events = new UnityEngine.Events.UnityEvent();

    void OnEnable()
    {
        // TapGestureのdelegateに登録
        GetComponent<TapGesture>().Tapped += tappedHandle;
    }

    void OnDisable()
    {
        UnsubscribeEvent();
    }

    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        // 登録を解除
        GetComponent<TapGesture>().Tapped -= tappedHandle;
    }

    void tappedHandle(object sender, System.EventArgs e)
    {
        Debug.Log("a");
        //処理したい内容
        if (m_events != null) { m_events.Invoke(); }
    }
}
