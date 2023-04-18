using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI dayText;
    
    public void ChangeDayText(int day)
    {
        dayText.text = $"Day: {day}";
    }
}
