using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Current { get; private set; }

    public HealthUI HealthUI { get { return HealthUI.Current; } }
    public InformationUI InformationUI{ get { return InformationUI.Current; }}

    float MaxHealthCache = 100;
    public float MaxHealth
    {
        get { return MaxHealthCache; }
        set
        {
            MaxHealthCache = value;
            HealthUI.HealthBar.maxValue = MaxHealthCache;
        }
    }
    float HealthCache;
    public float Health
    {
        get { return HealthCache; }
        set
        {
            HealthCache = value;
            HealthUI.HealthBar.value = HealthCache;
            if (HealthCache > MaxHealth) { HealthCache = MaxHealth; }
        }
    }
    float GoldCache;
    public float Gold
    {
        get { return GoldCache; }
        set
        {
            GoldCache = value;
            InformationUI.GoldText.text = GoldCache.ToString();
        }
    }

    public float Attack = 50.0f;
    public float Defence = 20.0f;

    void Awake()
    {
        Current = this;
    }

    public void RefleshAll(){
        MaxHealth = MaxHealth;
        Health = MaxHealth;
        Gold = 0;
    }
}