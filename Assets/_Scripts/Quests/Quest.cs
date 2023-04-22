using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest", order = 0)]
public class Quest : ScriptableObject
{
    
    [SerializeField] private List<string> objectives;
    [SerializeField] List<Reward> rewards = new List<Reward>();

    [System.Serializable]
    class Reward
    {
        public int number;
        public ScriptableObject item;
    }
    
    public string GetTitle()
    {
        return name;
    }

    public string GetObjectiveCount()
    {
        return objectives.Count.ToString();
    }

    public IEnumerable<string> GetObjectives()
    {
        return objectives;
    }

    public bool HasObjective(string obj)
    {
        
        return objectives.Contains(obj);
    }
}
