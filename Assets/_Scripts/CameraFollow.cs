using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void FixedUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = _playerTransform.position.x;
        temp.y = _playerTransform.position.y;

        transform.position = temp;
    }
}
