using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Equipment",menuName = "Inventory/Equipment")]
public class Equipment : Item  
{
    public SkinnedMeshRenderer mesh;

    public int armor;
    public int damage;

	public override  void Use () 
	{
        base.Use();
	}
	
	
}
