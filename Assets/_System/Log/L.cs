using Ito.Log;
using UnityEngine;

namespace Ito.Log
{
    public enum LogLevels : int
    {
        Dev = 0,
        Log = 1,
        Warn = 2,
        Error = 3,
        None = 4,
    }
}

public static class L
{
    public static void Dev(object place, object obj)
    {
        if ((int)Settings.Log.LogLevel.Value > (int)LogLevels.Dev) return;
        Debug.Log("(Dev)[" + place + "] " + obj);
    }

    public static void Log(object place, object obj)
    {
        if ((int)Settings.Log.LogLevel.Value > (int)LogLevels.Log) return;
        Debug.Log("[" + place + "] " + obj);
    }

    public static void Warn(object place, object obj)
    {
        if ((int)Settings.Log.LogLevel.Value > (int)LogLevels.Warn) return;
        Debug.LogWarning("[" + place + "] " + obj);
    }

    public static void Error(object place, object obj)
    {
        if ((int)Settings.Log.LogLevel.Value > (int)LogLevels.Error) return;
        Debug.LogError("[" + place + "] " + obj);
    }
}
