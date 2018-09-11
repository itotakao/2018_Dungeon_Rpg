using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Current { get; private set; }

    public PlayerManager PlayerManager{ get { return PlayerManager.Current; }}
    public ItemManager ItemManager { get { return ItemManager.Current; } }
    public LogManager LogManager { get { return LogManager.Current; } }
    public EventUI EventUI { get { return EventUI.Current; } }

    public delegate void PlayEnterEvent();
    public PlayEnterEvent OnPlayEnterEvent;
    public delegate void PlayingEvent();
    public PlayingEvent OnPlayingEvent;
    public delegate void PlayExitEvent();
    public PlayExitEvent OnPlayExitEvent;

    //public delegate void ButtonAction();
    //public static event ButtonAction OnButtonEvent;

    public Monster CurrentMonster { get; private set; }
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
        CurrentMonster = GetRandamMonster();
        CurrentMonster.Initilize();
        Debug.Log(CurrentMonster.GetIcon());
        EventUI.EventImage.sprite = CurrentMonster.GetIcon();
        EventUI.EventText.text = CurrentMonster.GetHealth().ToString();
    }

    public Monster GetRandamMonster()
    {
        return MonsterList[Random.Range(0, MonsterList.Length)];
    }

    public void LotteryDropItem(Monster monster)
    {
        if (monster.LotteryNormalItem()) { ItemManager.AddItem(monster.GetNormalDropItem()); }
        if (monster.LotteryRarelItem()) { ItemManager.AddItem(monster.GetRareDropItem()); }
    }

    public void Battle()
    {
        PlayerManager.Health -= 20;
        LogManager.Push("<color=red>体力40ダメージ</color>");
        PlayerManager.Gold += 30;
        LogManager.Push("<color=green>30ゴールド獲得</color>");

        CurrentMonster.Damage(PlayerManager.Attack);
        EventUI.EventText.text = CurrentMonster.GetHealth().ToString();

        if (CurrentMonster.GetHealth() <= 0)
        {
            LogManager.Push("<color=green>アイテムを獲得</color>");
            LotteryDropItem(CurrentMonster);
        }
    }
}
