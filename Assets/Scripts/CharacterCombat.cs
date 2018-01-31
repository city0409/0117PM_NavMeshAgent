using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private Transform HPpos;
    private float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    private CharactorHealth myHealth;

    public System.Action OnAttack;

    private void Awake()
    {
        myHealth = GetComponent<CharactorHealth>();

    }

    private void Start()
    {
        HealthUIManager.instance.Create(HPpos, myHealth);
    }

    public void Update()
    {
        attackCoolDown -= Time.deltaTime;
    } 

    public void Attack(CharactorHealth targetHealth)
    {
        if (attackCoolDown <=0)
        {
            attackCoolDown = 1 / attackSpeed;
            targetHealth.TakeDamage(myHealth.Damage.GetValue());

            if (OnAttack!=null )
            {
                OnAttack.Invoke();
            }
        }

    }
}
