using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
     [SerializeField] private Sprite _sprite_1;
     [SerializeField] private Sprite _sprite_2;
     
     private SpriteRenderer _spriteRenderer;
     private Collider2D _collider;
     private void Awake()
     {
         _spriteRenderer = GetComponent<SpriteRenderer>();
         _collider = GetComponent<Collider2D>();
     }
     public void OpenDoor()
     {
         _spriteRenderer.sprite = _sprite_2;
         _collider.enabled = false;
     }
}
