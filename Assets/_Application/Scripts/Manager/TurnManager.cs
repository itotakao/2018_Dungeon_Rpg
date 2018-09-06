using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Current { get; private set; }

    public InformationUI InformationUI { get { return InformationUI.Current; } }

    public int Turn = 0;

    Text turnTextCache;
    public Text TurnText { get { return turnTextCache ? turnTextCache : turnTextCache = GetComponent<Text>(); } }

    void Awake()
    {
        Current = this;
    }

    public void AddTurn()
    {
        Turn++;
        Draw();
    }

    public void Draw()
    {
        TurnText.text = Turn.ToString() + " 日";
        InformationUI.SetDateText(Turn.ToString() + " 日");
    }
}
