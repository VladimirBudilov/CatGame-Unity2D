using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchView : MonoBehaviour
{
    [Header("View mode")]
    [SerializeField] private bool _sideView;
    [SerializeField] private bool _topView;
    
    [Header("Player prefabs")]
    [SerializeField] private GameObject _playerSV;
    [SerializeField] private GameObject _playerSVCamera;
    
    [SerializeField] private GameObject _playerTV;
    [SerializeField] private GameObject _playerTVCamera;
    
    public void Switch()
    {
        if (_sideView)
        {
            _playerSV.gameObject.SetActive(false);
            _playerSVCamera.gameObject.SetActive(false);

            _playerTV.transform.position = _playerSV.transform.position;
            _playerTV.gameObject.SetActive(true);
            _playerTVCamera.gameObject.SetActive(true);
            _sideView = false;
            _topView = true;
        }
        
        else if (_topView)
        {
            _playerSV.transform.position = _playerTV.transform.position;
            _playerSV.gameObject.SetActive(true);
            _playerSVCamera.gameObject.SetActive(true);
            
            
            _playerTV.gameObject.SetActive(false);
            _playerTVCamera.gameObject.SetActive(false);

            _sideView = true;
            _topView = false;
        }
    }
}
