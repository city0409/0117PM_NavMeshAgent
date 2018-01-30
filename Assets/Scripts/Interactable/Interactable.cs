using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour 
{
    public  float radius = 2f;
    [SerializeField]
    private Transform interactionTrans;
    public Transform InteractionTrans { get { return interactionTrans; } }

    private Transform playerTrans;
    private bool isFocus;

    private bool hasInteracted = false;

	private void Start () 
	{
        if (interactionTrans==null)
        {
            interactionTrans = transform;
        }
	}
	
	private void Update () 
	{
        if (isFocus )
        {
            if (!hasInteracted && Vector3.Distance (playerTrans .position , interactionTrans.position )<radius )
            {
                hasInteracted = true;
                Interact();
            }
        }
		
	}

    public virtual void Interact()
    {
        print("Interact ");
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
        if (interactionTrans==null)
        {
            interactionTrans = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTrans.position, radius);
    } 
}
