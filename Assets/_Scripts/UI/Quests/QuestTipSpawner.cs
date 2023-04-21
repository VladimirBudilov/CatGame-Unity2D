using System.Collections;
using System.Collections.Generic;
using GameDevTV.Core.UI.Tooltips;
using UnityEngine;

public class QuestTipSpawner : TooltipSpawner
{
    public override void UpdateTooltip(GameObject tooltip)
    {
        var status = GetComponent<QuestItemUI>().GetQuestStatus();
        tooltip.GetComponent<QuestTooltipUI>().Setup(status);
    }

    public override bool CanCreateTooltip()
    {
        return true;
    }
}
