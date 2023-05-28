using System.Collections;
using System.Collections.Generic;
using _Scripts.NPC_s;
using UnityEngine;
using UnityEngine.Serialization;

public class Baker : MonoBehaviour
{
    [SerializeField] private string bread = "Bread";
    [SerializeField] private string bugSpray = "Spray";

    public void GiveBread()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CatInventory>().GetItem(bread);
    }
    
    public void GiveBugSpray()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CatInventory>().GetItem(bugSpray);
    }
}
