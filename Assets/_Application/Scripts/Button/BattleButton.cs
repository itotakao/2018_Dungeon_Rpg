using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButton : MonoBehaviour {

    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public LogManager LogManager { get { return LogManager.Current; } }
    public GameManager GameManager { get { return GameManager.Current; } }
    public ItemManager ItemManager{ get { return ItemManager.Current; }}
    public EventManager EventManager{ get { return EventManager.Current; }}

    public void OnButton()
    {
        if (GameManager.IsNextTurn) { return; }

        PlayerManager.Health -= 20;
        LogManager.Push("<color=red>体力40ダメージ</color>");
        PlayerManager.Gold += 30;
        LogManager.Push("<color=green>30ゴールド獲得</color>");

        LogManager.Push("<color=green>アイテムを獲得</color>");

        if (EventManager.CurrentMonster.LotteryNormalItem()) { ItemManager.AddItem(EventManager.CurrentMonster.GetNormalDropItem()); }
        if (EventManager.CurrentMonster.LotteryRarelItem()) { ItemManager.AddItem(EventManager.CurrentMonster.GetRareDropItem()); }

        GameManager.IsNextTurn = true;
    }
}
