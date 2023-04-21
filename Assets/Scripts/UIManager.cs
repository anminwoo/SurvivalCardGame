using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI dayText;

    public Bar[] stateBars;
    
    public void ChangeDayText(int day)
    {
        dayText.text = $"Day: {day}";
    }

    public void ChangeStat(PlayerStat type, int amount)
    {
        stateBars[(int)type].Change(amount);
    }
}
