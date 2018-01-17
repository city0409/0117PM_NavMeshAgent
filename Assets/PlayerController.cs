using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour 
{
    [SerializeField]
    private Camera cam;
    private NavMeshAgent agent;
    private PlayerMotor moter;

    private void Awake () 
	{
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
                agent.SetDestination(hit.point);
            }
        }
	}
}
