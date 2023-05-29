using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.Dialogue
{
    public abstract class ConverseTrigger : MonoBehaviour
    {
        [SerializeField] protected string action;

        public virtual void Trigger(string actionToTrigger)
        {
        }
        public virtual void Trigger(Quest quest, string actionToTrigger)
        {
        }
    }
}