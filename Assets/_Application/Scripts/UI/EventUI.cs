using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{

    public static EventUI Current { get; private set; }

    public Image EventImage = null;
    public Text EventText = null;
    public Button BattleButton = null;
    public Button EscapeButton = null;

    void Awake()
    {
        Current = this;
    }
}