using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentButton : MonoBehaviour
{
    public BuildManager BuildManager{ get { return BuildManager.Current; }}
    public EquipmentUI EquipmentUI{ get { return EquipmentUI.Current; }}

    [SerializeField]
    EquipmentColumn equipmentColumn = null;

    public void OnButton()
    {
        if (!equipmentColumn.item) { return; }

        switch(equipmentColumn.item.GetKindOfItem()){

            case Item.KindOfItem.Weapon:
                EquipmentUI.Initialize();
                BuildManager.SetWeapon(equipmentColumn.item);
                equipmentColumn.DialogImage.ExChangeYellow();
                break;

            case Item.KindOfItem.Armor:
                BuildManager.SetArmor(equipmentColumn.item);
                break;

            case Item.KindOfItem.Familiar:
                BuildManager.SetFamilir(equipmentColumn.item);
                break;

            default:
#if UNITY_EDITOR
                Debug.LogError("装備品以外のステータスが入っています");
#endif
                break;
        }
    }
}