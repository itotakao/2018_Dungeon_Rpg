using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;
using Base;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Current { get; private set; }

    public BuildManager BuildManager{ get { return BuildManager.Current; }}
    public TextManager TextManager { get { return TextManager.Current; } }
    public BattleUI BattleUI { get { return BattleUI.Current; } }
    public InformationUI InformationUI { get { return InformationUI.Current; } }

    [SerializeField]
    string playerName = "";
    [SerializeField]
    float gold = 0;
    [SerializeField]
    int bagSize = 5;

    [SerializeField]
    float health = 100;

    [SerializeField]
    float baseMaxHealth = 100;
    [SerializeField]
    float baseAttack = 50.0f;
    [SerializeField]
    float baseDefence = 20.0f;
    [SerializeField]
    float baseSpeed = 100.0f;
    [SerializeField]
    float baseAttackInterval = 100.0f;

    [SerializeField]
    float addMaxHealth = 0;
    [SerializeField]
    float addAttack = 0;
    [SerializeField]
    float addDefence = 0;
    [SerializeField]
    float addSpeed = 0;
    [SerializeField]
    float addAttackInterval = 0;

    public Skill SkillA = null;
    public Skill SkillB = null;
    public Skill SkillC = null;

    void Awake()
    {
        Current = this;
    }

    public void Initilize()
    {
        SetHealth(GetMaxHealth());
        UpdateAllUI();
    }

    public void Reflesh()
    {
        SetHealth(GetMaxHealth());
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetBagSize()
    {
        return bagSize;
    }

    public float GetMaxHealth()
    {
        return baseMaxHealth + addMaxHealth + BuildManager.GetBuildStatus(Status.Health);
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetAttack()
    {
        return baseAttack + addAttack + BuildManager.GetBuildStatus(Status.Attack);
    }

    public float GetDefence()
    {
        return baseDefence + addDefence + BuildManager.GetBuildStatus(Status.Defence);
    }

    public float GetSpeed()
    {
        return baseSpeed + addSpeed + BuildManager.GetBuildStatus(Status.Speed);
    }

    public float GetGold()
    {
        return gold;
    }

    public float GetAttackInterval()
    {
        return baseAttackInterval - addAttackInterval - BuildManager.GetBuildStatus(Status.AttackSpeed);
    }

    public void SetHealth(float value)
    {
        health = value;
        if (GetHealth() > GetMaxHealth()) { SetHealth(GetMaxHealth()); }

        UpdateHealthUI();
    }

    public void SetGold(float value)
    {
        gold = value;
        if (gold < 0) { gold = 0; }

        UpdateGoldUI();
    }

    public void SetBaseMaxHealth(float value)
    {
        baseMaxHealth = value;
        if (GetHealth() > GetMaxHealth()) { SetHealth(GetMaxHealth()); }

        UpdateHealthUI();
    }

    public void SetAddMaxHealth(float value)
    {
        addMaxHealth = value;
        if (GetHealth() > GetMaxHealth()) { SetHealth(GetMaxHealth()); }

        UpdateHealthUI();
    }

    public void SetBaseAttack(float value)
    {
        baseAttack = value;
        if (baseAttack < 1) { baseAttack = 1; }
    }

    public void SetAddAttack(float value)
    {
        addAttack = value;
    }

    public void SetBaseDefence(float value)
    {
        baseDefence = value;
        if (baseDefence < 1) { baseDefence = 1; }
    }

    public void SetAddDefence(float value)
    {
        addDefence = value;
    }
    public void SetBaseSpeed(float value)
    {
        baseSpeed = value;
        if (baseSpeed < 1) { baseSpeed = 1; }
    }

    public void SetAddSpeed(float value)
    {
        addSpeed = value;
    }

    public void SetBaseAttackInterval(float value)
    {
        baseAttackInterval = value;
        if (baseAttackInterval < 1) { baseAttackInterval = 1; }

        UpdateAttackIntervalUI();
    }

    public void SetAddAttackInterval(float value)
    {
        addAttackInterval = value;

        UpdateAttackIntervalUI();
    }

    public void UseGold(float value)
    {
        if (gold < value)
        {
            TextManager.PushLog("ゴールドが足りません!!");
            return;
        }

        SetGold(gold - value);
    }

    public void AddGold(float value) { SetGold(gold + value); }

    public void Heal(float value) { SetHealth(health + value); }

    public void Damage(float value) { SetHealth(health - value); }

    void UpdateHealthUI()
    {
        BattleUI.PlayerHealthSlider.maxValue = GetMaxHealth();
        BattleUI.PlayerHealthSlider.value = GetHealth();
    }

    void UpdateGoldUI()
    {
        InformationUI.GoldText.text = GetGold().ToString();
    }

    void UpdateAttackIntervalUI()
    {
        BattleUI.PlayerAttackSlider.maxValue = GetAttackInterval();
    }

    void UpdateAllUI()
    {
        UpdateHealthUI();
        UpdateGoldUI();
        UpdateAttackIntervalUI();
    }
}