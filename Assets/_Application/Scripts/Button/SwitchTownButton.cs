using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTownButton : MonoBehaviour
{
    public GameManager GameManager { get { return GameManager.Current; } }

    public void OnButton()
    {
        if (GameManager.IsSwitchToTown) { return; }

        GameManager.IsSwitchToTown = true;
    }
}