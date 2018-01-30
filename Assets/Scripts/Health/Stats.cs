using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ Serializable]
public class Stats 
{
    [SerializeField ]
    private int baseValue;
    [SerializeField]
    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x); 
        //modifiers.ForEach(Final);
        return finalValue;
    }

    //public void  Final(int x)
    //{
    //    baseValue += x;
        
    //}


    public  void AddModifier (int modifier) 
	{
        if (modifier >0)
        {
            modifiers.Add(modifier);
        }
	}
	
	public  void RemoveModifier (int modifier) 
	{
        if (modifier > 0)
        {
            modifiers.Remove (modifier);
        }
    }
}
