using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    public static PlayerManager instance;

    [SerializeField]
    private GameObject  player;
    public GameObject Player { get { return player; } }


    private void Awake () 
	{
        instance = this;
	}
	
	
}
