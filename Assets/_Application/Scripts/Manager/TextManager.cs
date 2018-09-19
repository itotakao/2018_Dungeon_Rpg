using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}