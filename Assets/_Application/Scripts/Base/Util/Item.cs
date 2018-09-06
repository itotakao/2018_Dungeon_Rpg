using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum KindOfItem
    {
        Weapon,
        UseItem,
        Helmet,
        Armor,
        Arm,
        Boots,
        None
    }

    public enum Status
    {
        None,
        HP,
        Attack,
        Defence,
        Speed,
        Luck,
        AttackSpeed
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
    // アイテムの固有効果
    [SerializeField]
    private Status status;
    [SerializeField]
    private int addValue;

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
    public Status GetStatus()
    {
        return status;
    }
    public int GetValue()
    {
        return addValue;
    }
}
