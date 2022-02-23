using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndTest : MonoBehaviour
{
    [SerializeField] private GameObject _categoryCanvas;
    [SerializeField] private GameObject _resultTestCanvas;
    [SerializeField] private QuestionsMenu _qustionScript;
    [SerializeField] private GameObject _qestionCanvas;


    public void MainMenu()
    {
        _resultTestCanvas.SetActive(false);
        _categoryCanvas.SetActive(true);

    }

    public void RestartTest()
    {
        _resultTestCanvas.SetActive(false);
        _qestionCanvas.SetActive(true);
    }

}
