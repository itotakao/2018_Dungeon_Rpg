using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Current { get; private set; }

    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
    public ItemListUI ItemListUI { get { return ItemListUI.Current; } }

    [SerializeField] public ItemDictionary itemDictionary;
    public IDictionary<Item, int> ItemDictionary
    {
        get { return itemDictionary; }
        set { itemDictionary.CopyFrom(value); }
    }

    void Awake()
    {
        Current = this;
    }

    public void AddItem(Item item)
    {
        if (ItemDictionary.ContainsKey(item))
        {
            ItemDictionary[item]++;
        }
        else
        {
            ItemDictionary.Add(item, 1);
        }
        DrawItemBox(item);
    }

    public void DrawItemBox(Item item)
    {
        ItemListUI.Show(true);

        // アイテムが存在しているかどうか TODO:もっとスマートに　継承するか？
        int counter = 0;
        foreach (var image in ItemListUI.ItemImageList)
        {
            if (image.sprite && image.sprite.name == item.GetIcon().name)
            {
                if(itemDictionary[item] == 0)
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
        switch (item.GetStatus())
        {
            case Item.Status.HP:
                PlayerManager.Health += item.GetValue();
                break;
            case Item.Status.Attack:
                break;
            case Item.Status.AttackSpeed:
                break;
            case Item.Status.Defence:
                break;
            case Item.Status.Luck:
                break;
            case Item.Status.Speed:
                break;
            default:
#if UNITY_EDITOR
                Debug.LogError("エラー: 未知なるステータスが設定されています");
#endif
                break;
        }

        ItemDictionary[item]--;
        DrawItemBox(item);
    }
}
