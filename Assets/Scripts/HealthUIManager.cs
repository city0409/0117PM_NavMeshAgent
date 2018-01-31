using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIManager : MonoBehaviour 
{
    public static HealthUIManager instance;

    [SerializeField]
    private HealthUI healthUI;

    private void Awake () 
	{
        instance = this;
	}
	
	public  void Create (Transform target,CharactorHealth health) 
	{
        HealthUI newUI = Instantiate(healthUI, target.position, Quaternion.identity);
        newUI.transform.parent = transform;
        newUI.Init(target, health);
	}
}
