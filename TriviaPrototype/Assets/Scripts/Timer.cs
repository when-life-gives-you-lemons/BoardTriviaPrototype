using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 30f;
    private QuestionManager questionManager;
    private TMP_Text timerText;
    
    void Start()
    {
        timerText =  GetComponent<TMP_Text>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");
        if (timer <= 0f)
        {
            questionManager.ShowAnswers();
        }
    }
}
