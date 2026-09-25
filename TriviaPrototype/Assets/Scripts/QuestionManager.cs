using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] public List<TMP_Text> Questions = new List<TMP_Text>();
    [SerializeField] public List<TMP_Text> Answers = new List<TMP_Text>();

    public int questionNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        questionNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAnswers()
    {
        Answers[questionNumber].gameObject.SetActive(true);
    }

    public void NextQuestion()
    {
        Questions[questionNumber].gameObject.SetActive(false);
        questionNumber++;
        Questions[questionNumber].gameObject.SetActive(true);
    }
}
