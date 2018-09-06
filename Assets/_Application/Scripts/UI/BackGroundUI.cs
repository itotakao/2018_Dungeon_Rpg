using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundUI : MonoBehaviour
{
    public static BackGroundUI Current { get; private set; }

    void Awake()
    {
        Current = this;
    }
}
