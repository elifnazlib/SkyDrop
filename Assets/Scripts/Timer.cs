using System;
using UnityEngine;
using TMPro;

// This script is used to control the timer. (https://discussions.unity.com/t/simple-timer/56201)
public class Timer : MonoBehaviour
{
    [SerializeField] private float targetTime = 7.0f; // Target time for the timer
    [SerializeField] private TextMeshProUGUI timerText; // TextMeshProUGUI instance to show the timer on the screen
    private bool isTimerEnded = false; // Is used to check if the timer is ended
    [SerializeField] GameOver _gameOverScript; // Reference to the GameOver script
    private int count = 0; // Counter for the timer


    void Update()
    {
        if (!isTimerEnded) // If the timer is not ended
        {
            targetTime -= Time.deltaTime; // Decrease the target time by the time passed since the last frame
            timerText.text = TimeSpan.FromSeconds(targetTime).ToString(@"mm\:ss"); // Update the timer text on the screen
        }

        if (targetTime <= 0.0f) // If the target time is less than or equal to 0
        {
            if (count == 0) // If the timer is not ended yet
                TimerEnded(); // Call the TimerEnded method
        }
    }

    void TimerEnded()
    {
        count = 1; // Set the count to 1 to prevent multiple calls to TimerEnded
        isTimerEnded = true; // Set the timer as ended
        _gameOverScript.GameFinished(); // Call the GameFinished method from the GameOver script
        // timerText.text = "00:00"; // Set the timer text to 00:00
        Debug.Log("Timer has ended!"); // Debugging
        // TODO: Game Over Panel
    }
}