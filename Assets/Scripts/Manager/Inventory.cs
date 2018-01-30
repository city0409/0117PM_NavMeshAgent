using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    public static Inventory instance;

    public  List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    private int space = 3;

    private void Awake () 
	{
        if (instance !=null )
        {
            Debug.LogWarning("more than one instance");
            return;
        }
        instance = this;

    }
	
	public  bool  Add (Item item) 
	{
        if (item.isDefultItem) return false;
        if (items.Count >=space ) return false;
        items.Add(item);
        if (OnItemChangedCallBack!=null)
        {
            OnItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        if (items.Count < 0) return;
        
        items.Remove(item);
        if (OnItemChangedCallBack != null)
        {
            OnItemChangedCallBack.Invoke();
        }
    }
}
