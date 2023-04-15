using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private RaycastHit2D _hit;
    private float _distance = 5f;

    private int _layerNumber = 12;
    private int _layerMask;

    private void Start()
    {
        _layerMask = 1 << _layerNumber;
    }
    private void Update()
    {
        _hit = Physics2D.Raycast(transform.position, Rotate(), _distance, _layerMask);
        Debug.DrawRay(transform.position, Rotate() * _distance, Color.red);
    }
    public bool IsNear()
    {
        if (_hit.collider != null)
        {
            return true;
        }
        return false;
    }

    Vector2 Rotate()
    {
        if (transform.rotation.y == 0)
        {
            return Vector2.left;
        }
        return Vector2.right;
    }
}
