using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SketelonAnimator : MonoBehaviour
{
    private const float dampTime = 0.1f;

    private NavMeshAgent agent;
    [SerializeField]
    protected  Animator anim;

    private float speedPercent;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speedPercent", speedPercent, dampTime, Time.deltaTime);
    }
}