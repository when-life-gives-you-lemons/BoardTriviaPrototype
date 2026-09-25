using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 10f;
    [SerializeField] QuestionManager questionManager;
    private TMP_Text timerText;
    public bool isTimerRunning;
    
    void Start()
    {
        timerText =  GetComponent<TMP_Text>();
        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = timer.ToString("F0");
            }

            else
            {
                timer = 0;
                isTimerRunning = false;
                TimerEnded();
            }
        }
    }

    void TimerEnded()
    {
        questionManager.ShowAnswers();
    }
}
