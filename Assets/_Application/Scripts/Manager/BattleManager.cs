using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Current { get; private set; }

    public PlayerManager PlayerManager{ get { return PlayerManager.Current; }}
    public ItemManager ItemManager { get { return ItemManager.Current; } }
    public LogManager LogManager { get { return LogManager.Current; } }
    public BattleUI BattleUI { get { return BattleUI.Current; } }

    public delegate void PlayEnterEvent();
    public PlayEnterEvent OnPlayEnterEvent;
    public delegate void PlayingEvent();
    public PlayingEvent OnPlayEvent;
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
        BattleUI.BattleButton.enabled = show;
        BattleUI.EscapeButton.enabled = show;
    }

    public void CallRandamMonster()
    {
        CurrentMonster = GetRandamMonster();
        CurrentMonster.Initilize();
        Debug.Log(CurrentMonster.GetIcon());
        BattleUI.MonsterImage.sprite = CurrentMonster.GetIcon();
        BattleUI.EventText.text = CurrentMonster.GetHealth().ToString();
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
        //TODO : 要カプセル化
        BattleUI.BattleAnimator.SetTrigger("OnAttack");

        CurrentMonster.Damage(PlayerManager.Attack);
        BattleUI.EventText.text = CurrentMonster.GetHealth().ToString();

        if (CurrentMonster.GetHealth() <= 0)
        {
            LogManager.Push("<color=green>アイテムを獲得</color>");
            LotteryDropItem(CurrentMonster);
        }
    }

    public void OnPlayerBattle()
    {
        PlayerManager.AttackGauge -= PlayerManager.Speed * Time.deltaTime;
        if (PlayerManager.AttackGauge <= 0)
        {
            PlayerManager.AttackGauge = 100f;

            //TODO : 要カプセル化
            BattleUI.BattleAnimator.SetTrigger("OnAttack");

            CurrentMonster.Damage(PlayerManager.Attack);
            BattleUI.EventText.text = CurrentMonster.GetHealth().ToString();

            LogManager.Push("<color=green>40ダメージ 与えた</color>");
        }
    }

    public void OnEnemyBattle()
    {
        // TODO : マジックナンバー
        BattleUI.AttackSlider.value -= 5f * Time.deltaTime;
        if(BattleUI.AttackSlider.value <= 0){
            BattleUI.AttackSlider.value = BattleUI.AttackSlider.maxValue;

            PlayerManager.Health -= 20;
            LogManager.Push("<color=red>体力40ダメージ</color>");
        }
    }

    public void Reflesh()
    {
        BattleUI.AttackSlider.value = BattleUI.AttackSlider.maxValue;
    }
}
