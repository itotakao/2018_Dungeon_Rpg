using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public ItemManager ItemManager { get { return ItemManager.Current; } }

    Image itemImageCache;
    public Image ItemImage { get { return itemImageCache ? itemImageCache : itemImageCache = GetComponent<Image>(); } }

    public void OnButton()
    {
        if (!ItemImage.sprite) { return; }
        ItemManager.UseItem(ItemManager.GetItemFromIconName(ItemImage.sprite.name));
    }
}
