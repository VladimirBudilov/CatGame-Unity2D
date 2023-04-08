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
        _playerConversant = GameObject.FindObjectOfType<PlayerConversant>();
        gameObject.GetComponent<Button>().onClick.AddListener(() =>_playerConversant.StartDialogue(this, AIDialogue));
    }
}
