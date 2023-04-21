using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest", order = 0)]
public class Quest : ScriptableObject
{
    
    [SerializeField] private string[] objectives;

    public string GetTitle()
    {
        return name;
    }

    public string GetObjectiveCount()
    {
        return objectives.Length.ToString();
    }

    public string[] GetObjectives()
    {
        return objectives;
    }
}
