using UnityEngine;

public class QuestListUI : MonoBehaviour
{
    [SerializeField] GameObject questPrefab;
    QuestList questList;

    // Start is called before the first frame update
    void Start()
    {
        questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        questList.onUpdate += Redraw;
        Redraw();
    }

    private void Redraw()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }

        foreach (QuestStatus status in questList.GetStatuses())
        {
            var uiInstance = Instantiate(questPrefab, transform);
            uiInstance.GetComponent<QuestItemUI>().Setup(status);
        }
    }
}