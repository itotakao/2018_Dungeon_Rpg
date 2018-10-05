using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Current { get; private set; }

    public TextManager TextManager { get { return TextManager.Current; } }
    public BattleUI BattleUI { get { return BattleUI.Current; } }
    public InformationUI InformationUI { get { return InformationUI.Current; } }

    const int MaxBagSize = 5;

    [SerializeField]
    float maxHealthCache = 100;
    float maxHealth
    {
        get { return maxHealthCache; }
        set
        {
            maxHealthCache = value;

            BattleUI.PlayerHealthSlider.maxValue = maxHealthCache;
        }
    }

    float healthCache;
    float health
    {
        get { return healthCache; }
        set
        {
            healthCache = value;
            BattleUI.PlayerHealthSlider.value = healthCache;
            if (healthCache > maxHealth) { healthCache = maxHealth; }

            BattleUI.PlayerHealthSlider.value = healthCache;
        }
    }

    [SerializeField]
    float goldCache = 100;
    float gold
    {
        get { return goldCache; }
        set
        {
            goldCache = value;
            if (goldCache < 0) { goldCache = 0; }

            InformationUI.GoldText.text = goldCache.ToString();
        }
    }

    [SerializeField]
    float attack = 50.0f;

    [SerializeField]
    float defence = 20.0f;

    [SerializeField]
    float speedChache = 100.0f;
    float speed
    {
        get { return speedChache; }
        set
        {
            speedChache = value;
            if (speedChache < 1) { speedChache = 1; }
        }
    }

    [SerializeField]
    float attackIntervalCache = 100.0f;
    float attackInterval
    {
        get { return attackIntervalCache; }
        set
        {
            attackInterval = value;
            if (attackIntervalCache < 1) { attackIntervalCache = 1; }

            BattleUI.PlayerAttackSlider.maxValue = attackIntervalCache;
        }
    }

    void Awake()
    {
        Current = this;
    }

    public void Initilize()
    {
        BattleUI.PlayerHealthSlider.maxValue = maxHealth;
        BattleUI.PlayerAttackSlider.maxValue = attackInterval;

        health = maxHealth;
        gold = gold;
    }

    public void Reflesh()
    {
        health = maxHealth;
    }

    public int GetMaxBagSize()
    {
        return MaxBagSize;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetAttack()
    {
        return attack;
    }

    public float GetDefence()
    {
        return defence;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetGold()
    {
        return gold;
    }

    public float GetAttackInterval()
    {
        return attackInterval;
    }


    public void SetMaxHealth(float value)
    {
        maxHealth = value;
        if (health > maxHealth) { SetHealth(maxHealth); }
    }

    public void SetHealth(float value)
    {
        health = value;
    }

    public void SetAttackInterval(float value)
    {
        attackInterval = value;
    }

    public void SetGold(float value)
    {
        gold = value;
    }

    public void Damage(float value)
    {
        health -= value;
    }

    public void Heal(float value)
    {
        health += value;
    }

    public void AddGold(float value)
    {
        gold += value;
    }

    public void TakeGold(float value)
    {
        if (gold < value)
        {
            TextManager.PushLog("ゴールドが足りません!!");
            return;
        }
        gold -= value;
    }
}