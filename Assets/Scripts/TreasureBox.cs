using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : Interactable  
{
    [SerializeField]
    private Item[] items;
    private Animator anim;
    private bool isOpened;

	private void Start () 
	{
        anim = GetComponentInChildren<Animator>();
	}

    public override void Interact()
    {
        base.Interact();
        if (isOpened) return;
        isOpened = true;
        anim.SetTrigger("open");
        StartCoroutine(CollisonTreasures());
    }

    private IEnumerator CollisonTreasures () 
	{
        yield return new WaitForSeconds(0.5f);
        foreach (var item in items )
        {
            Inventory.instance.Add(item);
        }
	}
}
