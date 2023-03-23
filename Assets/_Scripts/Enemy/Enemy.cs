using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float _during;
    
    private SpriteRenderer _spriteRenderer;
    private Color _currentColor;
    

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentColor = _spriteRenderer.color;
    }

    private void StillLive()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(Coloring());
        StillLive();
    }

    IEnumerator Coloring()
    {
        _spriteRenderer.color= Color.red;
        
        yield return new WaitForSeconds(_during);

        _spriteRenderer.color = _currentColor;
    }
}
