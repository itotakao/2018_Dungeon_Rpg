using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.DemiLib;

public class TextManager : MonoBehaviour
{
    public static TextManager Current { get; private set; }

    public TextUI TextUI { get { return TextUI.Current; } }

    public int MaxLog = 4;
    public List<string> LogList;

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

    public void PopUpText(string text)
    {
        TextUI.popUpText.text = text;
        TextUI.popUpText.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), 0);
        TextUI.popUpText.transform.DOLocalMove(new Vector3(TextUI.popUpText.transform.localPosition.x, TextUI.popUpText.transform.localPosition.y +10, TextUI.popUpText.transform.localPosition.z), 1f).OnComplete(() => { TextUI.popUpText.text = null; });
    }
}