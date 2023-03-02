using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingHouse : MonoBehaviour
{
    [SerializeField] private GameObject _house;
    [SerializeField] private GameObject _street;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OffSceneHouse();
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

    void TransitionToSpawnPoint()
    {
        
    }
}
