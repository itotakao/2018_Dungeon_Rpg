using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemListUI : MonoBehaviour 
{
    public static ItemListUI Current { get; private set; }

    public Image[] ItemImageList;
    public Text[] CounterTextList;

    void Awake()
    {
        Current = this;
    }

    public void Show(bool isShow)
    {
        foreach (var item in ItemImageList) { item.enabled = isShow; }
    }
}