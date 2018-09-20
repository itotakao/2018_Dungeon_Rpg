using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//TODO : 役割持たせすぎ　分割する必要あり
public class BattleManager : MonoBehaviour
{
    public static BattleManager Current { get; private set; }

    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public ItemManager ItemManager { get { return ItemManager.Current; } }
    public TextManager TextManager { get { return TextManager.Current; } }
    public GameManager GameManager { get { return GameManager.Current; } }
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

    float playerAttackIntervalTime = 0;

    Tweener attackEffectTween = null;
    Tweener damageEffectTween = null;

    void Awake()
    {
        Current = this;
    }

    public void CallRandamMonster()
    {
        CurrentMonster = GetRandamMonster();
        CurrentMonster.Initilize();
        BattleUI.MonsterImage.sprite = CurrentMonster.GetIcon();
        BattleUI.HealthSlider.maxValue = CurrentMonster.GetMaxHealth();
        BattleUI.HealthSlider.value = CurrentMonster.GetHealth();
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

    public void OnBattleButton()
    {
        AttackEffect(PlayerManager.GetAttack(), Color.red);
        CurrentMonster.Damage(PlayerManager.GetAttack());
        BattleUI.HealthSlider.value = CurrentMonster.GetHealth();
        DamageEffect(PlayerManager.GetAttack(), Color.yellow);

    }

    public bool CheckPlayerAttack()
    {
        playerAttackIntervalTime += PlayerManager.GetSpeed() * Time.deltaTime;
        if (playerAttackIntervalTime > PlayerManager.GetAttackInterval())
        {
            playerAttackIntervalTime = 0;
            return true;
        }
        return false;
    }

    public bool CheckEnemyAttack()
    {
        BattleUI.AttackSlider.value -= CurrentMonster.GetSpeed() * Time.deltaTime;
        if (0 >= BattleUI.AttackSlider.value )
        {
            BattleUI.AttackSlider.value = BattleUI.AttackSlider.maxValue;
            return true;
        }
        return false;
    }

    public void OnPlayerBattle()
    {
        AttackEffect(PlayerManager.GetAttack(), Color.red);
        CurrentMonster.Damage(PlayerManager.GetAttack());
        BattleUI.HealthSlider.value = CurrentMonster.GetHealth();

        TextManager.PushLog(string.Format("<color=green>{0}ダメージ 与えた</color>", PlayerManager.GetAttack()));
    }

    public void OnEnemyBattle()
    {
        DamageEffect(CurrentMonster.GetAttack(), Color.yellow);

        PlayerManager.Damage(CurrentMonster.GetAttack());
        TextManager.PushLog(string.Format("<color=red>体力{0}ダメージ</color>", CurrentMonster.GetAttack()));
    }

    void AttackEffect(float attackValue, Color textColor)
    {
        GameManager.IsAnimation = true;

        attackEffectTween.Kill();
        attackEffectTween = BattleUI.MonsterImage.transform.DOShakeScale(0.1f).OnComplete(() => { GameManager.IsAnimation = false; });

        BattleUI.BattleAnimator.SetTrigger("OnAttack");

        TextManager.PopUpText(attackValue.ToString(), textColor);
    }

    void DamageEffect(float damageValue, Color textColor)
    {
        GameManager.IsAnimation = true;

        damageEffectTween.Kill();
        damageEffectTween = BattleUI.MonsterImage.transform.DOScale(new Vector3(1.1f, 1.1f), 0.1f)
                    .OnComplete(() =>
                    {
                        BattleUI.MonsterImage.transform.localScale = Vector3.one;
                        GameManager.IsAnimation = false;
                    });
        ///
        // TODO : ダメージ演出を入れる
        ///

        TextManager.PopUpText(damageValue.ToString(), textColor);
    }

    public void ExitBattle()
    {
        LotteryDropItem(CurrentMonster);
        PlayerManager.AddGold(CurrentMonster.GetGold());
    }

    public void Reflesh()
    {
        BattleUI.AttackSlider.value = BattleUI.AttackSlider.maxValue;
        BattleUI.BattleAnimator.SetBool("OnAttack", false);
    }
}
