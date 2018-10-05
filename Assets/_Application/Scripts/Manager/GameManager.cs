using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Current { get; private set; }

    public bool IsBattle { get; set; }
    public bool IsAnimation { get; set; }

    // 切り換え用
    public bool IsSwitchToTown { get; set; }
    public bool IsSwitchToBattle { get; set; }

    void Awake()
    {
        Current = this;
    }

    public void Reflesh()
    {
        IsAnimation = false;
        IsSwitchToTown = false;
        IsSwitchToBattle = false;
    }
}
