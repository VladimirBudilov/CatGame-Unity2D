using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Dialogue;
using Unity.VisualScripting;
using UnityEngine;

public class Mother : MonoBehaviour
{
    [SerializeField] GameObject whiteSquarePrefab;
    [SerializeField] GameObject blackSquarePrefab;
    public void InstantiateWhiteSquare()
    {
        // Instantiate a white square prefab on the right side of the player
        // You can adjust the position and rotation of the instantiated object as needed
        Instantiate(whiteSquarePrefab, transform.position, Quaternion.identity);
    } 
// Note: You will need to have a reference to the white square prefab in your script, or load it dynamically using Resources.Load() or AssetBundles.
     public void InstantiateBlackSquare()
    {
        // Instantiate a white square prefab on the right side of the player
        // You can adjust the position and rotation of the instantiated object as needed
        Instantiate(blackSquarePrefab, transform.position, Quaternion.identity);
    } 
}
