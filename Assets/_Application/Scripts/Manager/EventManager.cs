using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Current { get; private set; }

    public EventUI EventUI{ get { return EventUI.Current; }}

    public delegate void PlayEnterEvent();
    public PlayEnterEvent OnPlayEnterEvent;
    public delegate void PlayingEvent();
    public PlayingEvent OnPlayingEvent;
    public delegate void PlayExitEvent();
    public PlayExitEvent OnPlayExitEvent;

    //public delegate void ButtonAction();
    //public static event ButtonAction OnButtonEvent;

    public Monster[] MonsterList;

    void Awake()
    {
        Current = this;
    }

    public void ShowBattleUI(bool show)
    {
        EventUI.BattleButton.enabled = show;
        EventUI.EscapeButton.enabled = show;
    }

    public void CallRandamMonster()
    {
        EventUI.EventImage.sprite = GetRandamMonster().GetIcon();
    }

    public Monster GetRandamMonster()
    {
        return MonsterList[Random.Range(0, MonsterList.Length)];
    }
}
