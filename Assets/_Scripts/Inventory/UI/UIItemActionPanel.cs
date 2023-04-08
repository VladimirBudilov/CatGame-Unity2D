using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIItemActionPanel : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab;
    public void AddButton(string name, Action onClickAction)
    {
        GameObject button = Instantiate(_buttonPrefab, transform);
        button.GetComponent<Button>().onClick.AddListener(() => onClickAction());
        button.GetComponentInChildren<TMPro.TMP_Text>().text = name;
    }
    public void Toggle(bool val)
    {
        if (val)
            RemoveOldButtons();
        gameObject.SetActive(val);
    }
    void RemoveOldButtons()
    {
        foreach (Transform transformChildObjects in transform)
        {
            Destroy(transformChildObjects.gameObject);
        }
    }
}
