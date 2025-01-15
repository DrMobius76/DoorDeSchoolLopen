using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndZoneEndGame : MonoBehaviour
{
    public CountDownTimer Timer; // Reference to the CountDownTimer
    [SerializeField] private TextMeshProUGUI TimeStatText; // Text to display the elapsed time
    [SerializeField] private GameObject StatCanvas; // Canvas to display stats
    [SerializeField] private TextMeshProUGUI Rank; // Text to display the rank

    private void OnTriggerEnter(Collider other)
    {
        // Calculate the total time elapsed
        Timer.CalculateTimeGone();

        // Convert time to minutes and seconds
        int minutes = Mathf.FloorToInt(Timer.totalTimeGone / 60f);
        int seconds = Mathf.FloorToInt(Timer.totalTimeGone % 60f);

        // Format time as MM:SS
        string formattedTime = $"{minutes:00}:{seconds:00}";

        // Activate the stats canvas and update the time text
        StatCanvas.SetActive(true);
        TimeStatText.text = $"Total Time: {formattedTime}";
        Timer.TimerScreen.SetActive(false);

        // Calculate percentage of max time
        float percentageTime = Timer.totalTimeGone / Timer.startTime;

        // Assign ranks based on percentage thresholds
        if (percentageTime <= 0.20f) // <= 20% of maxTime
        {
            Rank.text = "A";
            Rank.color = Color.green;
        }
        else if (percentageTime <= 0.40f) // 21%–40% of maxTime
        {
            Rank.text = "B";
            Rank.color = Color.green;
        }
        else if (percentageTime <= 0.60f) // 41%–60% of maxTime
        {
            Rank.text = "C";
            Rank.color = Color.yellow;
        }
        else if (percentageTime <= 0.80f) // 61%–80% of maxTime
        {
            Rank.text = "D";
            Rank.color = Color.yellow;
        }
        else // > 80% of maxTime
        {
            Rank.text = "F";
            Rank.color = Color.red;
        }
    }
}
