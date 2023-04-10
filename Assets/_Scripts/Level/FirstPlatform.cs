using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlatform : Platform
{
    [SerializeField] private Color _startColor;
    public override void Reset()
    {
        _isAllowedToJump = true;
        _spriteRenderer.color = _startColor;
        _counter = 0;
    }
}
