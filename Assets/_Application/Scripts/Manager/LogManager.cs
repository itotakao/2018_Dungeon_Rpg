using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{

    public static LogManager Current { get; private set; }

    public Text LogText;
    public int MaxLog = 4;
    public List<string> LogList;

    void Awake()
    {
        Current = this;
    }

    public void Push(string log)
    {
        if (log == "") { return; }
        LogList.Add(log);
        if (LogList.Count > MaxLog) { LogList.RemoveAt(0); }
        DrawText();
    }

    public void DrawText()
    {
        LogText.text = "";
        foreach (var log in LogList)
        {
            LogText.text += log + "\n";
        }
    }
}