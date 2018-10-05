using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BuyItemButton : MonoBehaviour
{
    public ItemManager ItemManager { get { return ItemManager.Current; } }
    public PlayerManager PlayerManager { get { return PlayerManager.Current; } }

    [SerializeField]
    Item item = null;
    [SerializeField]
    float needGold = 0;

    [SerializeField]
    Text nameText = null;
    [SerializeField]
    Image iconImage = null;
    [SerializeField]
    Text informationText = null;
    [SerializeField]
    Text needGoldText = null;

    void Start()
    {
        nameText.text = item.GetItemName();
        iconImage.sprite = item.GetIcon();
        informationText.text = item.GetInformation();
        needGoldText.text = needGold.ToString() + " G";
    }

    public void OnButton()
    {
        if (PlayerManager.GetGold() < needGold) { return; }

        PlayerManager.TakeGold(needGold);
        ItemManager.AddItem(item);
    }
}