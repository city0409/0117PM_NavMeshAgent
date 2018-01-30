using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharactorHealth 
{

	private void Start () 
	{
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChange;

    }
	
	private void OnEquipmentChange(Equipment newItem, Equipment oldItem) 
	{
        if (newItem !=null)
        {
            damage.AddModifier(newItem.damage);
            armor.AddModifier(newItem.armor);
        }

        if (oldItem !=null)
        {
            damage.RemoveModifier(oldItem.damage);
            armor.RemoveModifier(oldItem.armor);
        }
	}
}
