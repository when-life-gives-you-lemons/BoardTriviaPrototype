using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace DefaultNamespace
{
    public class HTTPTest : MonoBehaviour
    
    {
        public int NextQuestion;
        public QuestionManager questionManager;
        void Start()
        {
            // A correct website page.
            StartCoroutine(GetQuestions("http://192.168.0.215:8000/question.json"));
        }

        IEnumerator GetQuestions(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError("Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError("HTTP Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                        break;
                }
                
                
            }
        }

        public void Update()
        {
            if ( NextQuestion!= questionManager.questionNumber)
            {
                System.Diagnostics.Debug.WriteLine(questionManager.questionNumber);
            
                NextQuestion= questionManager.questionNumber; //this updates the code
                System.Diagnostics.Debug.WriteLine(NextQuestion);

            }
        }
    }
}