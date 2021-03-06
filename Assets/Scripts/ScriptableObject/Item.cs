﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject  
{
    new public string name = "New Item";
    public Sprite icon;
    public bool isDefultItem;

    public virtual void Use()
    {
        Debug.Log("Use"+name );
        RemoveFromInventory();
    }

    protected void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);    }
}
