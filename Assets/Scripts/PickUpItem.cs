using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable  
{
    [SerializeField]
    private Item item;

	public override  void Interact() 
	{
        base.Interact();
        print("be focus");
        PickUp();
    }

    private void PickUp() 
	{
        Destroy(gameObject);
	}
}
