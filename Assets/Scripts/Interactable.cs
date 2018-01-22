using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour 
{
    public  float radius = 2f;

    private Transform playerTrans;
    private bool isFocus;

    private bool hasInteracted = false;

	private void Start () 
	{
		
	}
	
	private void Update () 
	{
        if (isFocus )
        {
            if (!hasInteracted && Vector3.Distance (playerTrans .position ,transform .position )<radius )
            {
                hasInteracted = true;
                Interact();
            }
        }
		
	}

    public virtual void Interact()
    {

    }

    public void OnFocus(Transform playerTrans)
    {
        this.playerTrans = playerTrans;
        hasInteracted = false;
        isFocus = true;
    }

    public void OnDeFocus( )
    {
        hasInteracted = false;
        this.playerTrans = null ;
        isFocus = false ;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    } 
}
