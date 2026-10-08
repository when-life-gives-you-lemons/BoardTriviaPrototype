using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObjects/NewScriptableObject")]
public class NewScriptableObject : ScriptableObject
{
    public string prefabName;

    public int numberofQuestionsToCreate;
    [SerializeField] public List<TMP_Text> Questions = new List<TMP_Text>();
    public GameObject QuestionPrefab;
   
    // Start is called before the first frame update

    public void start()
    {
        ScriptableObject.CreateInstance(typeof(NewScriptableObject));
    }
  
}


