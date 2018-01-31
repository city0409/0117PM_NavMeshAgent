using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour 
{
    private Transform target;
    private Transform cameraTrans;
    private CharactorHealth myHealth;


	public  void Init (Transform target,CharactorHealth health) 
	{
        myHealth = health;
        this.target = target;

        cameraTrans = Camera.main.transform;
	}
	
	private void Update () 
	{
        if (target ==null )
        {
            Destroy(this.gameObject);
            return;
        }
        transform.position = target.position;
        transform.LookAt(new Vector3(cameraTrans.position.x, transform.position.y, cameraTrans.position.z));
	}
}
