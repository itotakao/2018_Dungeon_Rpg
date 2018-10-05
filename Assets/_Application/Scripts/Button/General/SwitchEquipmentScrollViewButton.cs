using UnityEngine;

public class SwitchEquipmentScrollViewButton : MonoBehaviour
{
    public EquipmentUI EquipmentUI { get { return EquipmentUI.Current; } }

    [SerializeField]
    EquipmentUI.KindOfEquipmentItem kindOfEquipment;

    public void OnButton()
    {
        EquipmentUI.SwitchEquipmentScrollView(kindOfEquipment);
    }
}