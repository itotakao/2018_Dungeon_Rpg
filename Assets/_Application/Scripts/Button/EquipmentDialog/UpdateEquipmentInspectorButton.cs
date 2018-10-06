using UnityEngine;

[RequireComponent(typeof(EquipmentColumn))]
public class UpdateEquipmentInspectorButton : MonoBehaviour
{
    public EquipmentUI EquipmentUI { get { return EquipmentUI.Current; } }

    EquipmentColumn equipmentColumnCache = null;
    EquipmentColumn EquipmentColumn { get { return equipmentColumnCache ? equipmentColumnCache : GetComponent<EquipmentColumn>(); } }

    public void OnButton()
    {
        EquipmentUI.UpdateInspectorUI(EquipmentColumn.item);
    }
}