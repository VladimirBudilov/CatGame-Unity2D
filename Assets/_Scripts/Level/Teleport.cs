using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
   [SerializeField] private GameObject _spawnPoint;
   private void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.CompareTag("Player") )
      {
         col.transform.position = _spawnPoint.transform.position;
      }
   }
}
