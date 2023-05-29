using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.Dialogue
{
    public class DiaogueQuestTrigger : ConverseTrigger
    {
        [SerializeField] protected UnityEvent<Quest, string> onQuestTrigger;
        [SerializeField] protected List<Quest> _listQuests = new List<Quest>();


        public override void Trigger(Quest quest, string actionToTrigger)
        {
            foreach (var currentQuest in _listQuests)
            {
                var objectives = currentQuest.GetObjectives();
                foreach (var objective in objectives)
                {
                    if (objective.reference == actionToTrigger)
                    {
                        onQuestTrigger?.Invoke(currentQuest, actionToTrigger);
                    }
                }
            }
        
        }
    }
}