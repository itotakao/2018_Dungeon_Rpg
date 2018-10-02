using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentColumn : MonoBehaviour
{
    public Item item = null;

    public bool IsLock { get { return lockIcon.activeSelf; } }

    [Space(10)]

    [SerializeField]
    Image iconImage = null;
    [SerializeField]
    Text nameText = null;
    [SerializeField]
    Text informationText = null;
    [SerializeField]
    GameObject lockIcon = null;

    public void SetItem(Item newItem)
    {
        item = newItem;
    }

    public void UpdateColumn()
    {
        if (!item) { 
            iconImage.sprite = null;
            nameText.text = null;
            informationText.text = null;
            return; 
        }

        iconImage.sprite = item.GetIcon();
        nameText.text = item.GetItemName();
        informationText.text = item.GetInformation();
    }
}