using System;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign in the inspector, a TMP Text to display the timer
    public GameObject loseScreenUI; // Assign the lose screen UI GameObject in the inspector

    private TimeSpan timeRemaining;
    private bool timerRunning = false;
    private float totalTime = 120.0f; // 2 minutes in seconds

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
                totalTime = 0;
                SetTimer(totalTime); // Ensure timer shows 00:00
                timerRunning = false;
                OnTimerEnd();
            }
            else
            {
                SetTimer(totalTime);
            }
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
        Debug.Log("Timer has ended!");
        // Activate the lose screen UI
        loseScreenUI.SetActive(true);
        // Pause the game
        Time.timeScale = 0;
    }
}
