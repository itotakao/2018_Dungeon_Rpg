using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Current { get; private set; }

    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public ItemManager ItemManager { get { return ItemManager.Current; } }
    public LogManager LogManager { get { return LogManager.Current; } }
    public GameManager GameManager{ get { return GameManager.Current; }}
    public BattleUI BattleUI { get { return BattleUI.Current; } }

    public delegate void PlayEnterEvent();
    public PlayEnterEvent OnPlayEnterEvent;
    public delegate void PlayerBattleEvent();
    public PlayerBattleEvent OnPlayerBattleEvent;
    public delegate void EnemyBattleEvent();
    public EnemyBattleEvent OnEnemyBattleEvent;
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

    }

    public void OnPlayerBattle()
    {
        PlayerManager.AttackGauge -= PlayerManager.Speed * Time.deltaTime;
        if (PlayerManager.AttackGauge <= 0)
        {
            PlayerManager.AttackGauge = 100f;
            GameManager.IsAnimation = true;
            //TODO : 要カプセル化
            BattleUI.MonsterImage.transform.DOShakeScale(0.1f).OnComplete(()=> { GameManager.IsAnimation = false; });
            BattleUI.BattleAnimator.SetTrigger("OnAttack");

            CurrentMonster.Damage(PlayerManager.Attack);
            BattleUI.EventText.text = CurrentMonster.GetHealth().ToString();

            LogManager.Push(string.Format("<color=green>{0}ダメージ 与えた</color>",PlayerManager.Attack));
        }
    }

    public void OnEnemyBattle()
    {
        // TODO : マジックナンバー
        BattleUI.AttackSlider.value -= CurrentMonster.GetSpeed() * Time.deltaTime;
        if (BattleUI.AttackSlider.value <= 0)
        {
            GameManager.IsAnimation = true;
            BattleUI.AttackSlider.value = BattleUI.AttackSlider.maxValue;
            BattleUI.MonsterImage.transform.DOPunchScale(new Vector3(1.5f, 1.5f), 0.1f).OnComplete(() => { GameManager.IsAnimation = false; });

            PlayerManager.Health -= 20;
            LogManager.Push("<color=red>体力40ダメージ</color>");
        }
    }

    public void ExitBattle()
    {
        LotteryDropItem(CurrentMonster);
        PlayerManager.Gold = CurrentMonster.GetGold();
    }

    public void Reflesh()
    {
        BattleUI.AttackSlider.value = BattleUI.AttackSlider.maxValue;
    }
}
