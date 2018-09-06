using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeButton : MonoBehaviour {

    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public LogManager LogManager { get { return LogManager.Current; } }
    public GameManager GameManager { get { return GameManager.Current; } }

    public void OnButton()
    {
        LogManager.Push("<color=green>逃走した</color>");
        GameManager.IsNextTurn = true;
    }
}
