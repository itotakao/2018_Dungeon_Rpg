using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUI : Base.NormalDialog
{
    public ItemManager ItemManager { get { return ItemManager.Current; } }
    public BuildManager BuildManager { get { return BuildManager.Current; } }

    public EquipmentColumn[] equipmentColumnList = null;

    [SerializeField] Item item;//kesu

    void Start()
    {
        ItemManager.AddItem(item);
        Debug.Log(ItemManager.WeaponBox.Count);
        for (int i = 0; i < ItemManager.WeaponBox.Count;i++)
        {
            Debug.Log("a");   
            equipmentColumnList[i].SetItem(ItemManager.WeaponBox[i]);
            equipmentColumnList[i].UpdateColumn();
        }
    }
}