using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryMenu : MonoBehaviour
{

    [SerializeField] private Text _nameCategoryTextField;
    [SerializeField] private GameObject _qustionCanvas;
    [SerializeField] private GameObject _categoryCanvas;
    [SerializeField] private QuestionsMenu _quesionMenuScript;

    public List<Categories> categories = new List<Categories>();
    public int currentCategory;
    public Button btnCategory;

    const string nameButtonPrev = "PrevCategoryBtn";
    const string nameButtonNext = "NextCategoryButton";

    private void Awake()
    {
        currentCategory = 0;
        VisibleCategory(currentCategory);
        _nameCategoryTextField.text = categories[currentCategory].nameCategory;
    }

    public void VisibleCategory(int current)
    {
        btnCategory.GetComponentInChildren<Image>().sprite = categories[currentCategory].spriteCategory;
        _nameCategoryTextField.text = categories[current].nameCategory;
    }

    public void SelectCategory(Button btn)
    {
        if (btn.name== nameButtonPrev)
        {
            currentCategory--;
            if (currentCategory < 0) currentCategory = categories.Count - 1;
        }

        if (btn.name == nameButtonNext)
        {
            currentCategory++;
            if (currentCategory > categories.Count-1) currentCategory = 0;
        }

        VisibleCategory(currentCategory);

    }

    public void EnterCategory()
    {
        _categoryCanvas.SetActive(false);
        _qustionCanvas.SetActive(true);
        _quesionMenuScript.currentCategory = currentCategory;
    }

}
