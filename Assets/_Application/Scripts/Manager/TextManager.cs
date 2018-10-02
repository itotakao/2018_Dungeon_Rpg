using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Battle;

public class TextManager : MonoBehaviour
{
    public static TextManager Current { get; private set; }

    public TextUI TextUI { get { return TextUI.Current; } }

    public int MaxLog = 4;
    public List<string> LogList;

    Tweener popUpTween = null;

    void Awake()
    {
        Current = this;
    }

    public void PushLog(string log)
    {
        if (log == "") { return; }
        LogList.Add(log);
        if (LogList.Count > MaxLog) { LogList.RemoveAt(0); }
        DrawLog();
    }

    public void DrawLog()
    {
        TextUI.LogText.text = "";
        foreach (var log in LogList)
        {
            TextUI.LogText.text += log + "\n";
        }
    }

    public void ClerLog()
    {
        TextUI.LogText.text = "";
    }

    // TODO : 複数表示するできるようにする
    public void PopUpText(string text, Color color)
    {
        popUpTween.Kill();

        TextUI.popUpText.text = text;
        TextUI.popUpText.color = color;

        TextUI.popUpText.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);

        popUpTween = TextUI.popUpText.transform.DOLocalMove(new Vector3(TextUI.popUpText.transform.localPosition.x, TextUI.popUpText.transform.localPosition.y + 10, TextUI.popUpText.transform.localPosition.z), 1.0f)
              .OnComplete(() => { TextUI.popUpText.text = null; });
    }
}