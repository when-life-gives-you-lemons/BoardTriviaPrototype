using System;

//    [Serializable]
  //  public class Question
   // {
    //    public string QuestionText;
     //   public string[] Answers;
      //  public int CorrectAnswerIndex;
   // }

[Serializable]//lets JSON utility generate code
   public class SendQuestionToServer
   {
       public int id;
       public string[] answers;
       public int time;
   }