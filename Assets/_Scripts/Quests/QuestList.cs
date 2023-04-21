using System.Collections;
using System.Collections.Generic;
using _Scripts.Quests;
using UnityEngine;

public class  QuestList : MonoBehaviour
{
    [SerializeField] private QuestStatus[] statuses;

    public IEnumerable<QuestStatus> GetStatuses()
    {
        return statuses;
    }
}
