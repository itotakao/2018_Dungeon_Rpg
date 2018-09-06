using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Current { get; private set; }

    public bool IsNextTurn = false;

    void Awake()
    {
        Current = this;
    }

    public void Reflesh()
    {
        IsNextTurn = false;
    }
}
