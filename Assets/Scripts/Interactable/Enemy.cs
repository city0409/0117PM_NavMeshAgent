using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable  
{
    private PlayerManager playerManager;

    private CharacterCombat playerCombat;
    private CharactorHealth myHealth;

    private void Awake () 
	{
        myHealth = GetComponent<CharactorHealth>();
	}
	

	private void Start () 
	{
        playerManager = PlayerManager.instance;
        playerCombat = playerManager.Player.GetComponent<CharacterCombat>();
    }

    public override void Interact()
    {
        base.Interact();

        playerCombat.Attack(myHealth);
    }
}
