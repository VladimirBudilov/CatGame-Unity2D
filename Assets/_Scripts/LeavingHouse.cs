using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingHouse : MonoBehaviour
{
    [SerializeField] private GameObject _house;
    [SerializeField] private GameObject _street;
    [SerializeField] private Transform _spawnPoint;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Console.WriteLine("kslflsd");
            OffSceneHouse();
            TransitionToSpawnPoint(col);
            OnSceneStreet();
        }
    }
    void OffSceneHouse()
    {
        _house.gameObject.SetActive(false);
    }

    void OnSceneStreet()
    {
        _street.gameObject.SetActive(true);
    }

    void TransitionToSpawnPoint(Collider2D player)
    {
        Vector2 pos = player.transform.position;

        var targetPosition = _spawnPoint.position;
        pos.x = targetPosition.x;
        pos.y = targetPosition.y;
        
        player.transform.position = pos;
    }
}
