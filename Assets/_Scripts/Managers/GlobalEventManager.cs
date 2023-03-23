using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static Action<InventoryItemInfo> OnGetItemInInventoryAction;
    public static void SayGetItemInInventory(InventoryItemInfo item)
    {
        OnGetItemInInventoryAction?.Invoke(item);
    }
}
