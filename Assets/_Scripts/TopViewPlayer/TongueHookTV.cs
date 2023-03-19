using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class TongueHookUp : MonoBehaviour
{
    [SerializeField] private float hookSpeed = 20f;
    [SerializeField] private float maxHookDistance = 40f;
    [SerializeField] private float offSetX = 1;
    [SerializeField] private float offSetY = 1;
    private float hookDistance;
    private Vector2 originalPos;
    private GameObject enemy;
    private bool wasEnemyHooked;
    private bool isHooking;
    private Rigidbody2D rb;

    private void Awake()
    {
        wasEnemyHooked = false;
        isHooking = false;
        rb = GetComponent<Rigidbody2D>();
        hookDistance = 0;
        originalPos = new Vector2(transform.parent.position.x, transform.parent.position.y);
    }
    
    void Update()
    {
        originalPos = new Vector2(transform.parent.position.x, transform.parent.position.y);
        if (Input.GetKeyDown(KeyCode.C) && !isHooking && !wasEnemyHooked)
        {
            StartHooking();
        }
        ReturnHook();
    }

    private void BringEnemy()
    {
        if (wasEnemyHooked)
        {
            var finalPos = new Vector2(originalPos.x + offSetX, originalPos.y + offSetY);
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, finalPos, maxHookDistance);
            wasEnemyHooked = false;
        }
    }

    private void StartHooking()
    {
        isHooking = true;
        rb.isKinematic = false;
        rb.AddForce(transform.up * hookSpeed);
    }
    
    private void ReturnHook()
    {
        if (isHooking)
        {
            hookDistance = Vector2.Distance(transform.position, originalPos);
            if ((hookDistance > maxHookDistance) || wasEnemyHooked)
            {
                isHooking = false;
                rb.isKinematic = true;
                rb.velocity = new Vector2(0, 0);
                transform.position = originalPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Enemy>())
        {
            enemy = col.gameObject;
            wasEnemyHooked = true;
        }
        BringEnemy();
    }
}
