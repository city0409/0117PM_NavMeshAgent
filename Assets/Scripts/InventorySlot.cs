﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour 
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Button removeButton;

    private Item item;

	public  void AddItem (Item newItem) 
	{
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
	}
	
	public  void ClearItem () 
	{
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
	}

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item !=null )
        {
            item.Use();
        }
    }
}