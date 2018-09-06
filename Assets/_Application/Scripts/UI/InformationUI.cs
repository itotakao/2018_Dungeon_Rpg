using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUI : MonoBehaviour {
    public static InformationUI Current { get; private set; }

    public Text GoldText;
    public Text DateText;

    void Awake()
    {
        Current = this;
    }

    public void SetGoldText(string str)
    {
        GoldText.text = str;
    }

    public void SetDateText(string str)
    {
        DateText.text = str;
    }
}
