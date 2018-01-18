using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour 
{
    
    private Camera cam;
    private NavMeshAgent agent;
    private PlayerMotor moter;

    private Interactable focus;

    private void Awake () 
	{
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        moter = GetComponent<PlayerMotor>();

    }

    private void Update () 
	{
        if (Input .GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics . Raycast (ray ,out hit,200))
            {
                moter .MoveToPoint (hit.point);
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable!=null )
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        focus.OnFocus(transform);
        moter.FollowTarget(newFocus);
    }

    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocus();
        focus = null;

        moter.StopFollowTarget();
    }
}
