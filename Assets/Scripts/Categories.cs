using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Category", menuName = "QIUZ Game/Category")]
public class Categories : ScriptableObject
{

    public string nameCategory;
    public Sprite spriteCategory;
    public List<Questions> questionsCategory = new List<Questions>();


}
