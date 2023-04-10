using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   [SerializeField] protected GameObject _nextPlatform;
   [SerializeField] protected GameObject _spawnPoint;
   [SerializeField] protected bool _isAllowedToJump;
   [SerializeField] protected Color _color;

   protected SpriteRenderer _spriteRenderer;
   protected int _counter;
   private void Awake()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }
   private void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.CompareTag("Player"))
      {
         if (_counter == 1)
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
   public virtual void Reset()
   {
      _spriteRenderer.color = _color;
      _isAllowedToJump = false;
      _counter = 0;
   }
}
