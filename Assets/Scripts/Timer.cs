using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 60f;
    private bool timerIsRunning = false;
    private GameUIManager uIManager;

    public void Init(float seconds)
    {
        timeRemaining = seconds;
        timerIsRunning = true;
        uIManager = GameUIManager.Instance;
    }

    public void DeInit()
    {
        timerIsRunning = false;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                uIManager.OnRoundEnd(); // do the things here when the time expries
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        uIManager.TimerText(string.Format("{0:00}:{1:00}", minutes, seconds), timeRemaining);
    }
}
