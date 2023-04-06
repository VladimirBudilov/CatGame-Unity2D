using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RPG.Dialogue;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RPG.Dialogue
{
    public class PlayerConversant : MonoBehaviour
    {
        [SerializeField] private Dialogue currentDialogue;
        private DialogueNode currentNode = null;
        private bool isChoosing = false;

        private void Awake()
        {
            currentNode = currentDialogue.GetRootNode();
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
            isChoosing = false;
            Next();
        }
        public void Next()
        {
            var numPlayerResp = currentDialogue.GetPlayerChildren(currentNode).Count();
            if (numPlayerResp > 0)
            {
                isChoosing = true;
                return;
            }
            var children = currentDialogue.GetAIChildren(currentNode).ToArray();
             currentNode = children[Random.Range(0, children.Length)];
        }
        public bool HasNext()
        {
            return currentDialogue.GetAllChildren(currentNode).Any();
        }
        
        
    }
}
