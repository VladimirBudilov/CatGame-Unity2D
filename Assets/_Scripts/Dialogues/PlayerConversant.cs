using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RPG.Dialogue;
using RPG.UI;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RPG.Dialogue
{
    public class PlayerConversant : MonoBehaviour
    {
        private Dialogue currentDialogue;
        private DialogueNode currentNode = null;
        private bool isChoosing = false;
        private AIConversant currentConversant = null;
        private string playerName = "Cat";
        public event Action onConversationUpdated;

        public bool IsActive()
        {
            return currentDialogue != null;
        }

        public void StartDialogue(AIConversant newConversant, Dialogue newDialogue)
        {
            currentConversant = newConversant;
            currentDialogue = newDialogue;
            currentNode = currentDialogue.GetRootNode();
            TriggerEnterAction();
            onConversationUpdated();
        }

        public void Quit()
        {
            TriggerExitAction();
            currentConversant = null;
            currentDialogue = null;
            currentNode = null;
            isChoosing = false;
            onConversationUpdated();
        }

        public bool IsChoosing()
        {
            return isChoosing;
        }

        public string GetText()
        {
            return currentNode != null ? currentNode.GetText() : "";
        }

        public IEnumerable<DialogueNode> GetChoices()
        {
            return currentDialogue.GetPlayerChildren(currentNode);
        }

        public void SelectChoice(DialogueNode chosenNode)
        {
            currentNode = chosenNode;
            TriggerEnterAction();
            isChoosing = false;
            Next();
        }

        public void Next()
        {
            var numPlayerResp = currentDialogue.GetPlayerChildren(currentNode).Count();
            if (numPlayerResp > 0)
            {
                isChoosing = true;
                TriggerExitAction();
                onConversationUpdated();
                return;
            }
            var children = currentDialogue.GetAIChildren(currentNode).ToArray();
            TriggerExitAction();
            currentNode = children[Random.Range(0, children.Length)];
            TriggerEnterAction();
            onConversationUpdated();
        }

        public bool HasNext()
        {
            return currentDialogue.GetAllChildren(currentNode).Any();
        }

        private void TriggerEnterAction()
        {
            if (currentNode != null)
            {
                TriggerAction(currentNode.GetOnEnterAction());
            }
        }

        private void TriggerExitAction()
        {
            if (currentNode != null)
            {
                TriggerAction(currentNode.GetOnExitAction());
            }
        }

        private void TriggerAction(string action)
        {
            if (action == "") return;
            foreach (var trigger in currentConversant.GetComponents<DialogueTrigger>())
            {
                trigger.Trigger(action);
            }
        }

        public string GetCurrentSpeakerName()
        {
            return isChoosing ? playerName : currentConversant.GetAIConversantName();
        }
    }
}
