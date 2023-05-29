using System.Collections;
using System.Collections.Generic;
using RPG.Dialogue;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : ConverseTrigger
{
    [SerializeField] protected UnityEvent onDialogueTrigger;
    public override void Trigger(string actionToTrigger)
    {
        if (actionToTrigger == action)
        {
            onDialogueTrigger?.Invoke();
        }
    }
}
