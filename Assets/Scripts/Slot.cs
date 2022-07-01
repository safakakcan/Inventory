using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [Header("Slot")]
    public string displayName;

    private Equipment equipment = null;
    private bool blocked = false;
    public Equipment Equipment { get { return equipment; } }
    public bool Blocked { get { return blocked; } }

    [Header("Slot UI")]
    public UnityEngine.UI.Text nameText;
    public UnityEngine.UI.Text equipmentNameText;
    public GameObject blockedIcon;

    void Start()
    {
        nameText.text = displayName;
        equipmentNameText.text = string.Empty;
        blockedIcon.SetActive(blocked);
    }

    public void SetEquipment(Equipment equipment)
    {
        this.equipment = equipment;
        equipmentNameText.text = this.equipment.displayName;
    }

    public void SetBlocked(bool blocked)
    {
        this.blocked = blocked;
        blockedIcon.SetActive(blocked && equipment == null);
    }

    public void Unequip(Slot[] slots)
    {
        if (equipment != null)
        {
            foreach (var slotIndex in equipment.equipmentRule.blockedSlots)
            {
                slots[slotIndex].SetBlocked(false);
            }

            equipment = null;
            equipmentNameText.text = string.Empty;
        }
    }
}
