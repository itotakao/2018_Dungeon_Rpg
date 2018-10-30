using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Status
{
    None,
    Health,
    Attack,
    Defence,
    Speed,
    AttackSpeed
}

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum KindOfItem
    {
        Weapon,
        UseItem,
        Armor,
        Accessory,
        Familiar,
        None
    }

    //　アイテムの種類
    [SerializeField]
    private KindOfItem kindOfItem;
    //　アイテムのアイコン
    [SerializeField]
    private Sprite icon;
    //　アイテムの名前
    [SerializeField]
    private string itemName;
    //　アイテムの情報
    [SerializeField]
    private string information;
    [SerializeField]
    private float sellGold;
    // アイテムの固有効果
    [SerializeField]
    private float health;
    [SerializeField]
    private float attack;
    [SerializeField]
    private float defence;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float attackSpeed;

    public KindOfItem GetKindOfItem()
    {
        return kindOfItem;
    }
    public Sprite GetIcon()
    {
        return icon;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public string GetInformation()
    {
        return information;
    }
    public float GetSellGold()
    {
        return sellGold;
    }
    public float GetStatus(Status status)
    {
        switch(status){
            case Status.Health:
                return health;

            case Status.Attack:
                return attack;

            case Status.Defence:
                return defence;

            case Status.Speed:
                return speed;

            case Status.AttackSpeed:
                return attackSpeed;
            default:
                return 0;
        }
    }
}