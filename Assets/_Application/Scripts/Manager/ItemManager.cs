﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Current { get; private set; }

    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public ItemListUI ItemListUI { get { return ItemListUI.Current; } }
    public EquipmentUI BuildUI { get { return EquipmentUI.Current; } }

    // アイテムはスタックするためDictonaryで数を管理しています
    [SerializeField] public ItemDictionary itemDictionary;
    public IDictionary<Item, int> ItemDictionary
    {
        get { return itemDictionary; }
        set { itemDictionary.CopyFrom(value); }
    }

    public List<Item> WeaponBox { get; private set; }
    public List<Item> ArmorBox { get; private set; }
    public List<Item> AccessoryBox { get; private set; }
    public List<Item> FamiliarBox { get; private set; }

    void Awake()
    {
        Current = this;

        WeaponBox = new List<Item>();
        ArmorBox = new List<Item>();
        AccessoryBox = new List<Item>();
        FamiliarBox = new List<Item>();
    }

    // TODO : もっとスマートに短くしたい
    public void AddItem(Item item)
    {
        switch (item.GetKindOfItem())
        {
            case Item.KindOfItem.UseItem:

                if (ItemDictionary.ContainsKey(item))
                {
                    ItemDictionary[item]++;
                }
                else
                {
                    ItemDictionary.Add(item, 1);
                }
                UpdateItemBox(item);

                break;

            case Item.KindOfItem.Weapon:

                // HACK : 手持ち数を超えた処理
                // TODO : アイテムいっぱい演出を追加する必要あり
                if (WeaponBox.Count > PlayerManager.GetBagSize()) { return; }

                WeaponBox.Add(item);
                UpdateWeaponBox(item);

                break;

            case Item.KindOfItem.Armor:

                ArmorBox.Add(item);
                UpdateArmorBox(item);

                break;


            case Item.KindOfItem.Accessory:

                AccessoryBox.Add(item);
                UpdateAccessoryBox(item);

                break;

            case Item.KindOfItem.Familiar:

                FamiliarBox.Add(item);
                UpdateFamiliarBox(item);

                break;
        }
    }

    public void UpdateItemBox(Item item)
    {
        ItemListUI.Show(true);// これいらないかも

        // アイテムが存在しているかどうか TODO:もっとスマートに　継承するか？
        int counter = 0;
        foreach (var image in ItemListUI.ItemImageList)
        {
            if (image.sprite && image.sprite.name == item.GetIcon().name)
            {
                if (itemDictionary[item] == 0)
                {
                    ItemListUI.ItemImageList[counter].sprite = null;
                    ItemListUI.CounterTextList[counter].text = "0";
                    return;
                }
                ItemListUI.ItemImageList[counter].sprite = item.GetIcon();
                ItemListUI.CounterTextList[counter].text = ItemDictionary[item].ToString();
                return;
            }
            counter++;
        }

        // アイテムを追加
        counter = 0;
        foreach (var image in ItemListUI.ItemImageList)
        {
            if (!image.sprite)
            {
                ItemListUI.ItemImageList[counter].sprite = item.GetIcon();
                ItemListUI.CounterTextList[counter].text = ItemDictionary[item].ToString();
                return;
            }
            counter++;
        }
    }

    public void UpdateWeaponBox(Item item)
    {
        BuildUI.UpdateEquipmentColumnUI();
    }

    public void UpdateArmorBox(Item item)
    {

    }

    public void UpdateAccessoryBox(Item item)
    {

    }

    public void UpdateFamiliarBox(Item item)
    {

    }

    public Item GetItemFromIconName(string iconName)
    {
        foreach (KeyValuePair<Item, int> pair in ItemDictionary)
        {
            if (pair.Key.GetIcon().name == iconName)
            {
                return pair.Key;
            }
        }

#if UNITY_EDITOR
        Debug.LogError("エラー：返すアイテムが見つかりません");
#endif
        return null;
    }
    public void UseItem(Item item)
    {
        PlayerManager.Heal(item.GetStatus(Status.Health));
        PlayerManager.SetAddAttack(item.GetStatus(Status.Attack));
        PlayerManager.SetAddDefence(item.GetStatus(Status.Defence));
        PlayerManager.SetAddSpeed(item.GetStatus(Status.Speed));
        PlayerManager.SetAddAttackInterval(item.GetStatus(Status.AttackSpeed));

        ItemDictionary[item]--;
        UpdateItemBox(item);
    }
}