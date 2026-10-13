using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestionManager : MonoBehaviour
{
    //public Question[] TheQuestions;
    [SerializeField] public List<TMP_Text> Questions = new List<TMP_Text>();
    [SerializeField] public List<TMP_Text> Answers = new List<TMP_Text>();
    [SerializeField] public List<GameObject> CorrectAnswer = new List<GameObject>();
    [SerializeField] public GameObject gameOverScreen;

    public int questionNumber;
    public UnityEvent<SendQuestionToServer> questionUpdate;

    [SerializeField] public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        questionNumber = 0;
        questionUpdate.AddListener(DisplayQuestion);
        NextQuestion();
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
        if (questionNumber >= Questions.Count - 1)
        {
            Debug.Log("no more quesitons!!!!");
            return;
        }
        CorrectAnswer[questionNumber].SetActive(true);
        Debug.Log("Displaying CorrectAnswer");

       
        Invoke("NextQuestion", 5f); //5 for testing purposes, can be longer for final

    }

    public void NextQuestion()
    {
        Questions[questionNumber].gameObject.SetActive(false);
        Answers[questionNumber].gameObject.SetActive(false);
        CorrectAnswer[questionNumber].SetActive(false);

        questionNumber++;
        Debug.Log("Next Question is " + questionNumber);
        
        SendQuestionToServer qdata = new SendQuestionToServer();
        qdata.time = 20;
        qdata.answers = Answers[questionNumber].text.Trim().Split(" ");
        qdata.id = questionNumber;
        questionUpdate.Invoke(qdata);
    }

    public void DisplayQuestion(SendQuestionToServer qdata)
    {
        if (questionNumber > Questions.Count)
        {
            gameOverScreen.SetActive(true);
            //qdata = "the" "Game" "Is" "Over"
        }
        else
        {
            Questions[qdata.id].gameObject.SetActive(true);
            Debug.Log("Displaying Question!");
            timer.timer = 10f;
            timer.isTimerRunning = true;
        }

    }
    
}

   
