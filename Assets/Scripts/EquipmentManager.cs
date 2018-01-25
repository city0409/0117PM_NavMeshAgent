using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    [SerializeField]
    private Equipment[] defultEquipments;
    private Equipment[] currentEquipment;
    private SkinnedMeshRenderer[] currentMesh;
    [SerializeField]
    private SkinnedMeshRenderer targetMesh;

    private Inventory inventory;
    [SerializeField]
    private Equipment testEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventory = Inventory.instance;

        int slotNum = System.Enum.GetNames(typeof(Equipment.EquipmentSlop)).Length;
        //defultEquipment = new Equipment[slotNum];
        currentEquipment = new Equipment[slotNum];
        currentMesh = new SkinnedMeshRenderer[slotNum];
        EquipDefultItem();
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment old = UnEquip(slotIndex);
        if (onEquipmentChanged !=null)
        {
            onEquipmentChanged.Invoke(newItem, old);
        }
        
        //UnEquip(slotIndex);
        currentEquipment[slotIndex] = newItem;
        SetEquipmentBlendShapers(newItem, 100);
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh) as SkinnedMeshRenderer;
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMesh[slotIndex] = newMesh;
    }
    public Equipment UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMesh[slotIndex] != null)
            {
                Destroy(currentMesh[slotIndex].gameObject);
                //currentMesh[slotIndex] = null;
            }

            Equipment old = currentEquipment[slotIndex];
            SetEquipmentBlendShapers(old, 0);
            inventory.Add(old);
            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged !=null)
            {
                onEquipmentChanged.Invoke(null, old);
            }
            return old;
        }
        return null;
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
        EquipDefultItem();
    }

    private void SetEquipmentBlendShapers(Equipment item, int weigth)
    {
        foreach (Equipment.EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weigth);
        }
    }

    private void EquipDefultItem()
    {
        foreach (var item in defultEquipments )
        {
            Equip(item);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UnEquipAll();
        }
    }
}
