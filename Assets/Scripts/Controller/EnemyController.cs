using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent ))]
public class EnemyController : MonoBehaviour 
{
    [SerializeField]
    private float attackRadius = 10f;

    private NavMeshAgent agent;
    private Transform targetTrans;
    [SerializeField]
    private float lookSpeed=4f;
    [SerializeField]
    private CharacterCombat combat;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    private void Start () 
	{
        targetTrans = PlayerManager.instance.Player.transform;

    }
	
	private void Update () 
	{
        if (targetTrans !=null )
        {
            float distance = Vector3.Distance(transform.position, targetTrans.position);
            if (distance <=attackRadius )
            {
                agent.SetDestination(targetTrans.position);
                if (distance <=agent .stoppingDistance )
                {
                    CharactorHealth playerHealth = targetTrans.GetComponent<CharactorHealth>();
                    if (playerHealth != null)
                        combat.Attack(playerHealth);

                    LookTarget();
                    //transform.LookAt(targetTrans);
                }
            }
        }
	}
    private void LookTarget()
    {
        Vector3 direction = (targetTrans .position - transform.position).normalized;
        if (direction == Vector3.zero) return;
        Quaternion lookQuaternion = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookQuaternion, Time.deltaTime * lookSpeed);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
