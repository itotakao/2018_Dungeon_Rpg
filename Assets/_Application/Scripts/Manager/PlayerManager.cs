using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Current { get; private set; }

    public TextManager TextManager { get { return TextManager.Current; } }
    public HealthUI HealthUI { get { return HealthUI.Current; } }
    public InformationUI InformationUI { get { return InformationUI.Current; } }

    [SerializeField]
    float maxHealthCache = 100;
    float maxHealth
    {
        get { return maxHealthCache; }
        set
        {
            maxHealthCache = value;

            HealthUI.HealthBar.maxValue = maxHealthCache;
        }
    }

    float healthCache;
    float health
    {
        get { return healthCache; }
        set
        {
            healthCache = value;
            HealthUI.HealthBar.value = healthCache;
            if (healthCache > maxHealth) { healthCache = maxHealth; }

            HealthUI.HealthBar.value = healthCache;
        }
    }

    [SerializeField]
    float goldCache = 0;
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
    float speed = 100.0f;

    [SerializeField]
    float attackInterval = 100.0f;

    void Awake()
    {
        Current = this;
    }

    public void Initilize()
    {
        maxHealth = maxHealth;
        health = maxHealth;
        gold = 0;
    }

    public void Reflesh()
    {
        health = maxHealth;
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