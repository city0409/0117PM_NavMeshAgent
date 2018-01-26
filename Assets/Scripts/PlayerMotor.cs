using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour 
{
    private NavMeshAgent agent;
    private Transform target;
    [SerializeField]
    private float lookSpeed = 4f;

    private void Awake () 
	{
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target )
        {
            agent.SetDestination(target.position);
            LookTarget();
        }
    } 

    public  void MoveToPoint (Vector3 point) 
	{
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius;
        target = newTarget.InteractionTrans;
        agent.updateRotation = false;
    }

    public void StopFollowTarget()
    {
        agent.stoppingDistance = 0f;
        target = null;
        agent.updateRotation = true;
    }

    private void LookTarget()
    {
        Vector3 direction = (target.position-transform.position ).normalized;
        if (new Vector3(direction.x, 0f, direction.z) == Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * lookSpeed);
            return;
        }
        Quaternion lookQuaternion = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookQuaternion, Time.deltaTime * lookSpeed);
    }
}
