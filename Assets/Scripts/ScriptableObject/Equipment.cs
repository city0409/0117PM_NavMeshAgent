using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Equipment",menuName = "Inventory/Equipment")]
public class Equipment : Item  
{
    public enum EquipmentSlop { Head,Chest,Legs,Weapon,Shield,Feet}
    public enum EquipmentMeshRegion { Legs,Arms,Torso}

    public SkinnedMeshRenderer mesh;

    public EquipmentSlop equipSlot;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armor;
    public int damage;

	public override  void Use () 
	{
        base.Use();
        EquipmentManager.instance.Equip(this);
	}
	
	
}
