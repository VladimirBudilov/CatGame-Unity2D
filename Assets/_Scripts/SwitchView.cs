using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{
    [SerializeField] private GameObject _playerTV;
    [SerializeField] private GameObject _playerSV;
    
    private bool _flag;

    public void Switch()
    {
        if (GameObject.Find("PlayerSV"))
        {
            Instantiate(_playerTV, transform.parent);
            Destroy(_playerSV);
        }

        if (GameObject.Find("PlayerTV"))
        {
            Instantiate(_playerSV, transform.parent);
            Destroy(_playerTV);
        }
    }
}
