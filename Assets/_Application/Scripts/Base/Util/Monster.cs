using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Monster", menuName = "CreateMonster")]
public class Monster : ScriptableObject
{
    public enum KindOfMonster
    {
        Normal,
        Boss
    }

    [SerializeField]
    private KindOfMonster kindOfMonster;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private string monsterName;
    [SerializeField]
    private float maxHealth;

    private float healthCache;
    [SerializeField]
    private float health
    { 
        get { return healthCache; }
        set 
        { 
            healthCache = value;
            if(healthCache > maxHealth){ healthCache = maxHealth; }
        }
    }
    [SerializeField]
    private float attack;
    [SerializeField]
    private float defence;
    [SerializeField]
    private Item[] normalDropList;
    [SerializeField]
    private float normalDropLate;
    [SerializeField]
    private Item[] rareDropList;
    [SerializeField]
    private float rareDropLate;

    public KindOfMonster GetKindOfMonster()
    {
        return kindOfMonster;
    }
    public Sprite GetIcon()
    {
        return icon;
    }
    public string GetMonsterName()
    {
        return monsterName;
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
    public Item[] GetNormalDropList()
    {
        return normalDropList;
    }
    public Item[] GetRareDropList()
    {
        return rareDropList;
    }
    public Item GetNormalDropItem()
    {
        return normalDropList[UnityEngine.Random.Range(0, normalDropList.Length)];
    }
    public Item GetRareDropItem()
    {
        return normalDropList[UnityEngine.Random.Range(0, rareDropList.Length)];
    }
    public bool LotteryNormalItem()
    {
        float rand = UnityEngine.Random.Range(0.0f, 100.0f);
        return rand <= normalDropLate ? true : false;
    }
    public bool LotteryRarelItem()
    {
        float rand = UnityEngine.Random.Range(0.0f, 100.0f);
        return rand <= rareDropLate ? true : false;
    }
}
