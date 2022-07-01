using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Equipment : Item
{
    [Header("Equipment")]
    public EquipmentType type;
    public EquipmentRule equipmentRule;

    public bool isEquipable(Slot[] slots)
    {
        bool preferredSlotAvailable = false;
        foreach (var index in equipmentRule.slotOrder)
        {
            if (!slots[index].Blocked && slots[index].Equipment == null)
            {
                preferredSlotAvailable = true;
                break;
            }
        }

        bool blockedSlotsAvailable = true;
        foreach (var index in equipmentRule.blockedSlots)
        {
            if (slots[index].Blocked || slots[index].Equipment != null)
            {
                blockedSlotsAvailable = false;
                break;
            }
        }

        bool matchesAreValid = true;
        foreach (var match in equipmentRule.equipmentMatches)
        {
            if (!match.allowed && (from slot in slots where slot.Equipment != null && slot.Equipment.type == match.type select slot).Any())
            {
                matchesAreValid = false;
                break;
            }
        }

        return preferredSlotAvailable && blockedSlotsAvailable && matchesAreValid;
    }

    public void Equip(Slot[] slots)
    {
        if (isEquipable(slots))
        {
            foreach (var index in equipmentRule.slotOrder)
            {
                if (!slots[index].Blocked && slots[index].Equipment == null)
                {
                    slots[index].SetEquipment(this);
                    break;
                }
            }

            foreach (var index in equipmentRule.blockedSlots)
            {
                slots[index].SetBlocked(true);
            }
        }
    }
}

[System.Serializable]
public enum EquipmentType
{
    OneHandedSword,
    TwoHandedSword,
    Shield,
    Orb
}