using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Key", menuName = "Items/New Key")]
public class KeyItemSO : ItemSO, IDestroyableItem, IItemAction
{
    [SerializeField] private string _doorName;
    [SerializeField] private List<ModifierData> _modifiersData = new List<ModifierData>();
    public string ActionName => "Open Door";
    public bool PerformAction(GameObject gameObject)
    {
        foreach (ModifierData data in _modifiersData)
        {
            data.OpenDoor.ActionAffect(GameObject.Find(_doorName));
        }
        return true;
    }
}

[Serializable]
public class ModifierData 
{
    public OpenDoorSO OpenDoor;
}
