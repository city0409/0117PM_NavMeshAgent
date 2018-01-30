using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : SketelonAnimator
{
    [SerializeField]
    private CharacterCombat combat;

	private void Start () 
	{
        combat.OnAttack += Attack;
	}
	
	private void Attack() 
	{
        anim.SetTrigger("attack");
	}
}
