using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField]
    private Slot[] slots = new Slot[2];
    [SerializeField]
    private List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEquipButton(int itemIndex)
    {
        items[itemIndex].equipButton.gameObject.SetActive(true);

        Equipment equipment;
        if(items[itemIndex].TryGetComponent<Equipment>(out equipment))
        {
            items[itemIndex].equipButton.interactable = equipment.isEquipable(slots);
        }
    }

    public void EquipItem(int itemIndex)
    {
        items[itemIndex].equipButton.gameObject.SetActive(false);

        Equipment equipment;
        if (items[itemIndex].TryGetComponent<Equipment>(out equipment))
        {
            equipment.Equip(slots);
        }
    }

    public void UnequipFromSlot(int slotIndex)
    {
        slots[slotIndex].Unequip(slots);
    }
}