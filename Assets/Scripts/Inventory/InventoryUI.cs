using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour 
{
    private Inventory inventory;
    [SerializeField]
    private GameObject inventoryUIOBJ;
    [SerializeField]
    private Transform itemsParent;

    private InventorySlot[] slots;

    private void Start () 
	{
        inventory = Inventory.instance;
        inventoryUIOBJ.SetActive(false);

        inventory.OnItemChangedCallBack += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update () 
	{

        if (Input .GetButtonDown ("Inventory"))
            inventoryUIOBJ.SetActive(!inventoryUIOBJ.activeSelf  );
	}

    private void UpdateUI()
    {
        for (int i = 0; i < slots .Length ; i++)
        {
            if (i< inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearItem();
            }
        }
    }
}
