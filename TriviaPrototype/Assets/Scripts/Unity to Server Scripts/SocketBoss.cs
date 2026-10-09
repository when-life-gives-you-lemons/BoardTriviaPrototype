/*using System;
using System.Collections.Generic;
using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using Debug = System.Diagnostics.Debug;


public class SocketBoss : MonoBehaviour
{
    public SocketIOUnity socket; //package reference for opening web server point.
   
    public InputField EventNameTxt; //data type?
    public InputField DataTxt;
    public Text ReceivedText;
    public InputField QuestionNumberCheck;
    //public GameObject objectToSpin;
    public GameObject questionObject;
    public QuestionManager questionManager;
    

    // Start is called before the first frame update
    void Start()
    {
        //TODO: check the Uri if Valid.
        var uri = new Uri("http://192.168.0.215:3000/"); //this is where the webserver goes
        socket = new SocketIOUnity(uri, new SocketIOOptions 
        {
            Query = new Dictionary<string, string> //pull a data type out of a database
                {
                    {"token", "UNITY" } //identifier 
                }
            ,
            EIO = EngineIO.V4 // declaring the engine as being version 4
            ,
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket //unity and the web port opening
        });
        socket.JsonSerializer = new NewtonsoftJsonSerializer(); //json for the website to process

        ///// reserved socketio events
        socket.OnConnected += (sender, e) =>
        {
            Debug.Print("socket.OnConnected");
        };
        socket.OnPing += (sender, e) =>
        {
            Debug.Print("Ping");
        };
        socket.OnPong += (sender, e) =>
        {
            Debug.Print("Pong: " + e.TotalMilliseconds);
        };
        socket.OnDisconnected += (sender, e) =>
        {
            Debug.Print("disconnect: " + e);
        };
        socket.OnReconnectAttempt += (sender, e) =>
        {
            Debug.Print($"{DateTime.Now} Reconnecting: attempt = {e}");
        };
        ////

        Debug.Print("Connecting...");
        socket.Connect();

        socket.OnUnityThread("spin", (data) =>
        {
            rotateAngle = 0;
        });
        socket.OnUnityThread("questionCheck", (data) =>
        {
            //something goes here

        });

        //ReceivedText.text = "";
        socket.OnAnyInUnityThread((name, response) =>
        {
            ReceivedText.text += "Received On " + name + " : " + response.GetValue().GetRawText() + "\n";
        });
    }

    async void OnApplicationQuit()
    {
        if (socket != null && socket.Connected) 
        {
            await socket.DisconnectAsync();
        }
        socket?.Dispose();
    }

    public void EmitTest()
    {
        string eventName = EventNameTxt.text.Trim().Length < 1 ? "hello" : EventNameTxt.text;
        //checks if longer than one to check if is not empty
        //error checker so the event name can't be something invalid
        string questionNumberCheck = QuestionNumberCheck.ToString();
        string txt = DataTxt.text;
        
        if (!IsJSON(txt))
        {
            //socket.Emit(eventName, txt);
            socket.Emit("questionCheck", questionNumberCheck);
        }
        else
        {
            //socket.EmitStringAsJSON(eventName, txt);
            socket.EmitStringAsJSON("questionCheck", questionNumberCheck);
        }
    }

    public static bool IsJSON(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) { return false; }
        str = str.Trim();
        if ((str.StartsWith("{") && str.EndsWith("}")) || //For object
            (str.StartsWith("[") && str.EndsWith("]"))) //For array
        {
            try
            {
                var obj = JToken.Parse(str);
                return true;
            }catch (Exception ex) //some other exception
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void EmitSpin()
    {
        socket.Emit("spin");
       
    }

    public void EmitQuestion()
    {
        socket.Emit("questionCheck");
    }

    public void EmitClass()
    {
        TestClass testClass = new TestClass(new string[] { "foo", "bar", "baz", "qux" });
        TestClass2 testClass2 = new TestClass2("lorem ipsum");
        QuestionNumberChecker questionNumberChecker = new QuestionNumberChecker(number: 0);
        
        socket.Emit("class", testClass2);
        socket.Emit("questionCheck", questionNumberChecker);
    }

    // our test class
    [System.Serializable]
    class TestClass
    {
        public string[] arr;

        public TestClass(string[] arr)
        {
            this.arr = arr;
        }
    }

    [System.Serializable]
    class TestClass2
    {
        public string text;

        public TestClass2(string text)
        {
            this.text = text;
        }
    }
    //
    public class QuestionNumberChecker
    {
        public int num;
        public QuestionManager questionManager;
        

        public QuestionNumberChecker(int number)
        {
            this.num = number;
        }


        
    }


    float rotateAngle = 45;
    readonly float MaxRotateAngle = 45;
    int CheckQuestion;
    public int NextQuestion;
     
    
    void Update()
    {
        if(rotateAngle < MaxRotateAngle)
        {
            rotateAngle++;
            //objectToSpin.transform.Rotate(0, 1, 0);
        }

        if ( NextQuestion!= questionManager.questionNumber)
        {
            Debug.WriteLine(questionManager.questionNumber);
            
            NextQuestion= questionManager.questionNumber; //this updates the code
            Debug.WriteLine(NextQuestion);

        }
        

        
    }
}*/