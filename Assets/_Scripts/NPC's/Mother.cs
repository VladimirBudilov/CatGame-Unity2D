using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.NPC_s;
using RPG.Dialogue;
using Unity.VisualScripting;
using UnityEngine;

public class Mother : MonoBehaviour
{
    [SerializeField] private string key = "Key";
    public void GiveKey()
    {
        Debug.Log("Key");
        GameObject.FindGameObjectWithTag("Player").GetComponent<CatInventory>().GetItem(key);
    }
}
