using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerButtons : MonoBehaviour
{
 // Called when the 2-minute button is clicked
    public void SetTwoMinutes()
    {
        TimeDataManager.Instance.TimerDuration = 120f; // Set timer to 2 minutes
    }

    // Called when the 3-minute button is clicked
    public void SetThreeMinutes()
    {
        TimeDataManager.Instance.TimerDuration = 180f; // Set timer to 3 minutes
    }

    // Called when the 5-minute button is clicked
    public void SetFiveMinutes()
    {
        TimeDataManager.Instance.TimerDuration = 300f; // Set timer to 5 minutes
    }
}
