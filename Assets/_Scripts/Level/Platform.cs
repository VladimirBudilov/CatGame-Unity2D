using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   [SerializeField] private GameObject _nextPlatform;
   [SerializeField] private GameObject _spawnPoint;
   [SerializeField] private bool _isAllowedToJump;
   [SerializeField] private Color _color;
   
   private SpriteRenderer _spriteRenderer;
   private int _counter;
   

   private void Awake()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.CompareTag("Player"))
      {
         if (_counter ==1)
         {
            return;
         }
         _spriteRenderer.color = _color;

         if (_isAllowedToJump == false )
         {
            col.transform.position = _spawnPoint.transform.position;
            return;
         }
         
         if (_nextPlatform == null)
         {
            return;
         }
         
         _nextPlatform.GetComponent<SpriteRenderer>().color = Color.yellow;
         _nextPlatform.GetComponent<Platform>()._isAllowedToJump = true;
         _counter++;
      }
   }
}
