using System;
using System.Collections.Generic;
using UnityEngine;
using SocketIOClient; 

public class SocketInit : MonoBehaviour
{
    //Server URL
    Uri _uri = new Uri("http://192.168.0.215:3000");
    
    // vars
    private string targetColor = "";
    private bool shouldUpdateColor = false;
    private SocketIOUnity socket;
    private bool shouldUpdateQuestion;
    private string question = "";
    public int questionNumber;
    

    private void Awake()
    {
        //initilaize the socket
        //this section does NOT connect to the server, it just sets up the socket
        socket = new SocketIOUnity(_uri, new SocketIOOptions
        {
            Query = new Dictionary<string, string>
            {
                {"token", "UNITY" }
            },
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
        });
        
        // listen for the event from the server
        socket.On("triviaResponse", response =>
        {
            string color = response.GetValue<string>();
            Debug.Log("Received trivia response: " + color);
            
            //socket is running in a background thread, set a target color flag to be detected in update, which is running on the main thread.
            targetColor = color;
            shouldUpdateColor = true;
        });

        // actually connect to the server via the new socket
        socket.Connect(); 
    }

    public void OnQuestionUpdate(SendQuestionToServer qdata)
    {
        Debug.Log("question needs update, sending to server");
        socket.Emit("message", "SetNewQuestion", JsonUtility.ToJson(qdata));
    }

    private void Update()
    {
        // check for that shouldUpdateColor flag on the background thread, and if it's set, update the color
            
        
        /*if (shouldUpdateQuestion = true)
        {
            socket.On("updateQuestion", response =>
            {
                int.TryParse(response.GetValue<string>(), out questionNumber);
            });
            Debug.Log(questionNumber);
            socket.Emit("updateQuestion", questionNumber);
                
        }*/
        
    }

    private void OnDestroy()
    {
        if (socket != null)
        {
            socket.Disconnect();
        }
    }
}