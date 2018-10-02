using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class EquipmentColumn : MonoBehaviour 
{
    public Item item = null;

    public bool IsLock { get { return lockIcon.activeSelf; }}

    [Space(10)]

    [SerializeField]
    Image iconImage = null;
    [SerializeField]
    Text nameText = null;
    [SerializeField]
    Text informationText = null;
    [SerializeField]
    GameObject lockIcon = null;


	void Start () {

        if (!item) { return; }

        iconImage.sprite = item.GetIcon();
        nameText.text = item.GetItemName();
        informationText.text = item.GetInformation();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}