using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class PlayerAnimator : SketelonAnimator 
{
    [SerializeField]
    private CharacterCombat combat;

    [SerializeField]
    private WeaponAnimSetDatas[] weaponAnimSetDatas;

    private WeaponAnimSetDatas currentAnimSetData;

    private const float dampTime = 0.1f;

    private float speedPercent;

	private void Start () 
	{
        combat.OnAttack += OnAttack;

        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        currentAnimSetData = weaponAnimSetDatas[0];
	}
	
    private void OnAttack()
    {
        int attackIndex = Random.Range(0, currentAnimSetData.attackIndex);
        anim.SetFloat("weaponIndex", currentAnimSetData.weaponIndex);
        anim.SetFloat("attackIndex", attackIndex);
        anim.SetTrigger("attack");
    }

    private void Update()
    {
        speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speedPercent", speedPercent, dampTime, Time.deltaTime);
    }

    private void OnEquipmentChanged(Equipment newItem,Equipment oldItem)
    {
        if (newItem !=null )
        {
            if (newItem .equipSlot ==Equipment .EquipmentSlop .Weapon )
            {
                WeaponAnimSetDatas animSetData = weaponAnimSetDatas.First(x => x.weapons.Contains(newItem));
                if (animSetData !=null)
                {
                    currentAnimSetData = animSetData;
                }
            }
        }
        else if (newItem ==null)
        {
            if (oldItem !=null && oldItem .equipSlot == Equipment.EquipmentSlop.Weapon)
                currentAnimSetData = weaponAnimSetDatas[0];
        }
    }

}
[System.Serializable]
public class WeaponAnimSetDatas
{
    public Equipment[] weapons;
    public int weaponIndex;
    public int attackIndex;
}