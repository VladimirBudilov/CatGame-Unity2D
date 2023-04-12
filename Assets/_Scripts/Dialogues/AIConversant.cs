using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Dialogue;
using UnityEngine;
using UnityEngine.UI;

public class AIConversant : MonoBehaviour
{
    [SerializeField] private Dialogue AIDialogue;
    private PlayerConversant _playerConversant;

    private void Start()
    {
        _playerConversant = FindObjectOfType<PlayerConversant>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
    
        if (Input.GetKeyDown(KeyCode.G))
        {
            _playerConversant.StartDialogue(this, AIDialogue);
        }
    }
}
