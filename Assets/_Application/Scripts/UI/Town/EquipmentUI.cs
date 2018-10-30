using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : Base.NormalDialog
{
    public static EquipmentUI Current { get; private set; }

    public ItemManager ItemManager { get { return ItemManager.Current; } }
    public BuildManager BuildManager { get { return BuildManager.Current; } }

    public enum KindOfEquipmentItem
    {
        Weapon,
        Armor,
        Accessory,
        Familiar,
    }
    public KindOfEquipmentItem CurrentKindOfEquipment { get; private set; }

    public EquipmentColumn[] WeaponEquipmentColumnList = null;
    public EquipmentColumn[] ArmorEquipmentColumnList = null;
    public EquipmentColumn[] AccessoryEquipmentColumnList = null;
    public EquipmentColumn[] FamiliarEquipmentColumnList = null;

    [SerializeField]
    GameObject weaponScrollView = null;
    [SerializeField]
    GameObject armorScrollView = null;
    [SerializeField]
    GameObject accessoryScrollView = null;
    [SerializeField]
    GameObject familiarScrollView = null;

    [SerializeField]
    Image weaponSwitchButtonImage = null;
    [SerializeField]
    Image armorSwitchButtonImage = null;
    [SerializeField]
    Image accessorySwitchButtonImage = null;
    [SerializeField]
    Image familiarSwitchButtonImage = null;

    [SerializeField]
    Image inspectorIconImage = null;
    [SerializeField]
    Text inspectorNameText = null;
    [SerializeField]
    Text inspectorInformationText = null;
    [SerializeField]
    Text inspectorStatusValueText = null;
    [SerializeField]
    Text inspectorSpecialStatusValueText = null;
    [SerializeField]
    Text inspectorSellGoldText = null;

    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        SwitchEquipmentScrollView(KindOfEquipmentItem.Weapon);
        UpdateInspectorUI(null);
        Show(false);
    }

    public void UpdateEquipmentColumnUI()
    {
        // ERROR : リスト以上のアイテムを入れるとエラーが出る
        switch (CurrentKindOfEquipment)
        {
            case KindOfEquipmentItem.Weapon:

                for (int i = 0; i < ItemManager.WeaponBox.Count; i++)
                {
                    WeaponEquipmentColumnList[i].SetItem(ItemManager.WeaponBox[i]);
                    WeaponEquipmentColumnList[i].UpdateColumn();
                }

                break;

            case KindOfEquipmentItem.Armor:

                for (int i = 0; i < ItemManager.ArmorBox.Count; i++)
                {
                    ArmorEquipmentColumnList[i].SetItem(ItemManager.WeaponBox[i]);
                    ArmorEquipmentColumnList[i].UpdateColumn();
                }

                break;

            case KindOfEquipmentItem.Accessory:

                for (int i = 0; i < ItemManager.AccessoryBox.Count; i++)
                {
                    AccessoryEquipmentColumnList[i].SetItem(ItemManager.WeaponBox[i]);
                    AccessoryEquipmentColumnList[i].UpdateColumn();
                }

                break;

            case KindOfEquipmentItem.Familiar:

                for (int i = 0; i < ItemManager.FamiliarBox.Count; i++)
                {
                    FamiliarEquipmentColumnList[i].SetItem(ItemManager.WeaponBox[i]);
                    FamiliarEquipmentColumnList[i].UpdateColumn();
                }

                break;
        }
    }

    public void UpdateInspectorUI(Item item)
    {
        if (!item)
        {
            inspectorIconImage.sprite = null;
            inspectorNameText.text = null;
            inspectorInformationText.text = null;
            inspectorStatusValueText.text = null;
            inspectorSpecialStatusValueText.text = null;
            inspectorSellGoldText.text = null;
            return;
        }

        inspectorIconImage.sprite = item.GetIcon();
        inspectorNameText.text = item.GetItemName();
        inspectorInformationText.text = item.GetInformation();
        //TODO : 能力値を5つ表示する形にする
        //inspectorStatusValueText.text = item.GetStatus().ToString() +" +" + item.GetValue().ToString();
        inspectorSpecialStatusValueText.text = null;// TODO : 付け足す
        inspectorSellGoldText.text = item.GetSellGold().ToString();
    }

    public void Initialize()
    {
        // TODO : 装備しているやつは黄色にする
        foreach (var equipmentColumn in WeaponEquipmentColumnList) { equipmentColumn.DialogImage.ExChangeGray(); }
        foreach (var equipmentColumn in ArmorEquipmentColumnList) { equipmentColumn.DialogImage.ExChangeGray(); }
        foreach (var equipmentColumn in AccessoryEquipmentColumnList) { equipmentColumn.DialogImage.ExChangeGray(); }
        foreach (var equipmentColumn in FamiliarEquipmentColumnList) { equipmentColumn.DialogImage.ExChangeGray(); }


    }

    public void SetCurrentKindOfEquipment(KindOfEquipmentItem kindOfEquipment)
    {
        CurrentKindOfEquipment = kindOfEquipment;
    }

    public void SwitchEquipmentScrollView(KindOfEquipmentItem kindOfEquipment)
    {
        SetCurrentKindOfEquipment(kindOfEquipment);

        weaponScrollView.SetActive(false);
        armorScrollView.SetActive(false);
        accessoryScrollView.SetActive(false);
        familiarScrollView.SetActive(false);

        weaponSwitchButtonImage.ExChangeWhite();
        armorSwitchButtonImage.ExChangeWhite();
        accessorySwitchButtonImage.ExChangeWhite();
        familiarSwitchButtonImage.ExChangeWhite();

        switch (CurrentKindOfEquipment)
        {
            case KindOfEquipmentItem.Weapon:

                weaponScrollView.SetActive(true);
                weaponSwitchButtonImage.ExChangeYellow();

                break;

            case KindOfEquipmentItem.Armor:

                armorScrollView.SetActive(true);
                armorSwitchButtonImage.ExChangeYellow();

                break;

            case KindOfEquipmentItem.Accessory:

                accessoryScrollView.SetActive(true);
                accessorySwitchButtonImage.ExChangeYellow();

                break;

            case KindOfEquipmentItem.Familiar:

                familiarScrollView.SetActive(true);
                familiarSwitchButtonImage.ExChangeYellow();

                break;
        }
    }
}