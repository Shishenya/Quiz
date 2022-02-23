using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsMenu : MonoBehaviour
{
    const string correctAnswer = "correct";
    const string uncorrectAnswer = "uncorrect";

    [SerializeField] private Text _textQuestionField;
    [SerializeField] private List<Button> buttonsAnswer = new List<Button>();
    [SerializeField] private GameObject _canvasResultGO;
    [SerializeField] private GameObject _canvasQuestionGO;
    [SerializeField] private GameObject _canvasEndTestGO;
    [SerializeField] private float _cooldownNewQuestionPerSecond = 1.5f;
    [SerializeField] private float _cooldownWinOrLoseViewPerSecond = 1f;
    
    private Categories _myCategory;
    private Questions _question;
    private List<Vector3> _positionButton = new List<Vector3>();
    private int _correctAnswerCount = 0;

    public int currentCategory;
    public int currentQuestion;
    public CategoryMenu category;


    public void Start()
    {
        _correctAnswerCount = 0;
        _canvasResultGO.SetActive(false);
        _canvasEndTestGO.SetActive(false);

        _myCategory = category.categories[currentCategory];
        currentCategory = category.currentCategory;
        currentQuestion = 0;
        _question = _myCategory.questionsCategory[currentQuestion];


        NextQuestion();
    }

    public void UpdateQuestionText(int index)
    {
        _question = _myCategory.questionsCategory[index];
        string textQuestion = _question.textQuestion;
        _textQuestionField.text = textQuestion;
    }

    public void UpdateButton()
    {

        for (int i = 0; i < buttonsAnswer.Count; i++)
        {
            Text btn = buttonsAnswer[i].GetComponentInChildren<Text>();
            btn.text = _question.answer[i];
            _positionButton.Add(btn.transform.position);
        }

        RandomButtonPosition();
    }

    private void RandomButtonPosition()
    {
        for (int i = 0; i < buttonsAnswer.Count; i++)
        {
            int rnd = Random.Range(0, _positionButton.Count);
            buttonsAnswer[i].transform.position = _positionButton[rnd];
            _positionButton.RemoveAt(rnd);
        }
    }

    public void ClickButtonQuestion(Button btn)
    {

        bool result = false;

        if (btn.name==correctAnswer)
        {
            Debug.Log("Верно");
            _correctAnswerCount++;
            result = true;
        }

        if (btn.name==uncorrectAnswer)
        {
            Debug.Log("Не верно");
            result = false;
        }

        currentQuestion++;

        StartCoroutine(canvasWinOrLoseView(result));

        if (currentQuestion > _myCategory.questionsCategory.Count-1)
        {
            Debug.Log("Все! Правильных ответов " + _correctAnswerCount);
        } else
        {
            Invoke("NextQuestion", _cooldownNewQuestionPerSecond);
        }

    }

    private void NextQuestion()
    {
        _canvasResultGO.SetActive(false);
        _canvasQuestionGO.SetActive(true);
        UpdateQuestionText(currentQuestion);
        UpdateButton();
    }

    IEnumerator canvasWinOrLoseView(bool result)
    {
        string textResult = "Не верно";
        if (result) textResult = "Верно!";

        if (currentQuestion > _myCategory.questionsCategory.Count - 1) Invoke("canvasEndTestView", _cooldownWinOrLoseViewPerSecond);

        _canvasResultGO.SetActive(true);
        _canvasResultGO.GetComponentInChildren<Text>().text = textResult;
        _canvasQuestionGO.SetActive(false);

        yield return new WaitForSeconds(_cooldownWinOrLoseViewPerSecond);
    }

    private void  canvasEndTestView()
    {
        string result = "Тест окончен. Всего правильных ответов " + _correctAnswerCount.ToString();
        _canvasResultGO.SetActive(false);
        _canvasQuestionGO.SetActive(false);
        _canvasEndTestGO.SetActive(true);

        _canvasEndTestGO.GetComponentInChildren<Text>().text = result;

    }


}
