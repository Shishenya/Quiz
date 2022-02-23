using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "QIUZ Game/Question")]
public class Questions : ScriptableObject
{
    public string textQuestion;
    public List<string> answer = new List<string>();

}
