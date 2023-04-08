using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OpenDoorModifier", menuName = "Items/Modifiers/Open Door Modifier", order = -10)]
public class OpenDoorModifierSO : OpenDoorSO
{
    public override void ActionAffect(GameObject gameObject)
    {
        gameObject.GetComponent<Door>().OpenDoor();
    }
}
