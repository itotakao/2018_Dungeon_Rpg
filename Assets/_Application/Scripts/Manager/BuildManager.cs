using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Current { get; private set; }

    [SerializeField]
    Item Weapon = null;
    [SerializeField]
    Item Armor = null;
    [SerializeField]
    Item Accessory = null;
    [SerializeField]
    Item Familiar = null;

    void Awake()
    {
        Current = this;
    }

    public void SetWeapon(Item item)
    {
        Weapon = item;
    }

    public void SetArmor(Item item)
    {
        Armor = item;
    }

    public void SetAccessory(Item item)
    {
        Accessory = item;
    }

    public void SetFamilir(Item item)
    {
        Familiar = item;
    }

    public Item GetWeapon()
    {
        return Weapon;
    }

    public Item GetArmor()
    {
        return Armor;
    }

    public Item GetAccessory()
    {
        return Accessory;
    }

    public Item GetFamiliar()
    {
        return Familiar;
    }
}