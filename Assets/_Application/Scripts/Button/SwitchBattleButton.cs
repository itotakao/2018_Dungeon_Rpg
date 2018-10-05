using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBattleButton : MonoBehaviour
{
    public GameManager GameManager { get { return GameManager.Current; } }

    public void OnButton()
    {
        if (GameManager.IsSwitchToBattle) { return; }

        GameManager.IsSwitchToBattle = true;
    }
}