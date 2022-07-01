using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Rule", menuName = "Scriptable Objects/Equipment Rule", order = 0)]
public class EquipmentRule : ScriptableObject
{
    [Tooltip("Set preferred slot index by order.")]
    public int[] slotOrder;
    [Tooltip("Set blocked slots by equipment.")]
    public int[] blockedSlots;
    [Tooltip("Set allowed equipment types.")]
    public EquipmentMatches[] equipmentMatches;
}

[System.Serializable]
public class EquipmentMatches
{
    public EquipmentType type;
    public bool allowed;
}