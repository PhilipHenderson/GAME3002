using System;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign in the inspector, a TMP Text to display the timer
    private TimeSpan timeRemaining;
    private bool timerRunning = false;
    private float totalTime = 120f; // 2 minutes in seconds

    private void Start()
    {
        SetTimer(totalTime);
        StartTimer();
    }

    private void Update()
    {
        if (timerRunning)
        {
            totalTime -= Time.deltaTime;
            if (totalTime <= 0)
            {
                timerRunning = false;
                totalTime = 0;
                OnTimerEnd();
            }
            SetTimer(totalTime);
        }
    }

    private void SetTimer(float timeInSeconds)
    {
        timeRemaining = TimeSpan.FromSeconds(timeInSeconds);
        timerText.text = string.Format("{0:D2}:{1:D2}", timeRemaining.Minutes, timeRemaining.Seconds);
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    private void OnTimerEnd()
    {
        // Timer has ended, do something here
        Debug.Log("Timer has ended!");
    }
}