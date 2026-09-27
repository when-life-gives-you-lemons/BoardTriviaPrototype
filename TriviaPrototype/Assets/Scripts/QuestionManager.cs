using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] public List<TMP_Text> Questions = new List<TMP_Text>();
    [SerializeField] public List<TMP_Text> Answers = new List<TMP_Text>();
    [SerializeField] public List<GameObject> CorrectAnser = new List<GameObject>();

    public int questionNumber;
    public UnityEvent questionUpdate;

    [SerializeField] public Timer timer;
    
    // Start is called before the first frame update
    void Start()
    {
        questionNumber = 0;
        questionUpdate = new UnityEvent();
        questionUpdate.AddListener(DisplayQuestion);
        Questions[questionNumber].gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAnswers()
    {
        Answers[questionNumber].gameObject.SetActive(true);
        Debug.Log("Displaying Answers");
        //after a delay show correct
        Invoke("ShowCorrectAnswer", 5f); //5 for testing purposes, can be longer for final
    }

    public void ShowCorrectAnswer()
    {
        CorrectAnser[questionNumber].SetActive(true);
        Debug.Log("Displaying CorrectAnswer");
        Invoke("NextQuestion", 5f); //5 for testing purposes, can be longer for final

    }
    
    public void NextQuestion()
    {
        
        Questions[questionNumber].gameObject.SetActive(false);
        Answers[questionNumber].gameObject.SetActive(false);
        CorrectAnser[questionNumber].SetActive(false);

        questionNumber++;
        Debug.Log("Next Question is " + questionNumber);
        questionUpdate.Invoke();
    }

    public void DisplayQuestion()
    {
        Questions[questionNumber].gameObject.SetActive(true);
        Debug.Log("Displaying Question!");
        timer.timer = 10f;
        timer.isTimerRunning = true;

    }
}
