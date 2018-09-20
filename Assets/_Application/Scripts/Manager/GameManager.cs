using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Current { get; private set; }

    public bool IsBattle = false;
    public bool IsAnimation = false;

    void Awake()
    {
        Current = this;
    }

    public void Reflesh()
    {
        IsAnimation = false;
    }
}
