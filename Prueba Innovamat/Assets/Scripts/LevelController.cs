using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] Text levelCountText;
    
    [SerializeField] NumberGenerator numberGenerator;
    [SerializeField] ScoreControl scoreControl;
    [SerializeField] TextControl textControl;

    [SerializeField] List<GameObject> buttonList;

    [SerializeField] int incorrectOptionsCount = 2;

    private int levelCount = 0;
    private int correctNumber;
    private int failsInLevel = 0;

    private List<int> incorrectNumbers;

    public void Start()
    {
        incorrectNumbers = new List<int>();

        GenerateLevel();
    }

    public void Update()
    {
        levelCountText.text = "Nivel: " + levelCount;
    }

    private void GenerateLevel() 
    {
        levelCount++;
        incorrectNumbers.Clear();
        failsInLevel = 0;

        correctNumber = numberGenerator.GenerateRandomNumber();

        for (int i = 0; i < incorrectOptionsCount; ++i)
        {
            incorrectNumbers.Add(numberGenerator.GenerateRandomNumber());
        }

        string textNumber = numberGenerator.GenerateNumberText(correctNumber);
        textNumber.Trim();

        textControl.NumberTextString = char.ToUpper(textNumber[0]) + textNumber.Substring(1);

        int correctNumberPlace = Random.Range(0, incorrectOptionsCount);

        int buttonListCount = 0;
        int incorrectNumberCount = 0;

        foreach (GameObject button in buttonList)
        {
            ButtonControl buttonControl = button.GetComponent<ButtonControl>();
            textControl.SpawningButton -= buttonControl.ButtonInto;
            textControl.SpawningButton += buttonControl.ButtonInto;

            buttonControl.OnClickButton -= CorrectAnswer;
            buttonControl.OnClickButton -= IncorrectAnswer;

            buttonControl.ResetParameters();

            if (buttonListCount == correctNumberPlace)
            {
                buttonControl.NumberInButton = correctNumber;
                buttonControl.CorrectAnswer = true;
                buttonControl.OnClickButton += CorrectAnswer;
            }
            else
            {
                buttonControl.OnClickButton += IncorrectAnswer;
                buttonControl.CorrectAnswer = false;
                buttonControl.NumberInButton = incorrectNumbers[incorrectNumberCount];

                incorrectNumberCount++;
            }

            buttonListCount++;
        }

        textControl.FaceInText();
    }

    private void CorrectAnswer() 
    {
        scoreControl.SucessCount++;

        foreach (GameObject button in buttonList) 
        {
            ButtonControl buttonControl = button.GetComponent<ButtonControl>();

            if (!buttonControl.ButtonPressed)
            {
                buttonControl.ClickButton(true);
            }
        }

        Invoke("GenerateLevel", 3.0f);
    }

    private void IncorrectAnswer() 
    {
        failsInLevel++;
        scoreControl.FailCount++;

        if (failsInLevel == incorrectOptionsCount) 
        {
            foreach (GameObject button in buttonList)
            {
                ButtonControl buttonControl = button.GetComponent<ButtonControl>();

                if (!buttonControl.ButtonPressed)
                {
                    buttonControl.ClickButton(true);
                }
            }

            Invoke("GenerateLevel", 3.0f);
        }
    }
}
