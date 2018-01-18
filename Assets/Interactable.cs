using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour 
{
    public  float radius = 2f;

    private Transform playerTrans;
    private bool isFocus;

	private void Start () 
	{
		
	}
	
	private void Update () 
	{
        if (isFocus )
        {
            if (Vector3 .Distance (playerTrans .position ,transform .position )<radius )
            {
                Interact();
            }
        }
		
	}

    public virtual void Interact()
    {
        print("be focus");

    }

    public void OnFocus(Transform playerTrans)
    {
        this.playerTrans = playerTrans;
        isFocus = true;
    }

    public void OnDeFocus( )
    {
        this.playerTrans = null ;
        isFocus = false ;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    } 
}
