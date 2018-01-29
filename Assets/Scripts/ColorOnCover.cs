using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColorOnCover : MonoBehaviour 
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private Renderer rend;

    private Color[] originalColors;

    private void Awake () 
	{
        if (rend==null)
        {
            rend = GetComponent<MeshRenderer>();
        }

        originalColors = rend.materials.Select(x => x.color).ToArray();
    
    }
	
    private void OnMouseEnter()
    {
        print("OnMouseEnter");
        foreach (Material item in rend .materials)
        {
            item .color = color;
        }
        //rend.material .color = Color.red;
    }
    private void OnMouseExit()
    {
        print("OnMouseExit");
        //rend.material.color = Color.green;
        for (int i = 0; i < rend.materials.Length; i++)
        {
            rend.materials[i].color = originalColors[i];
        }
    }
}
