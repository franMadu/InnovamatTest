using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla el comportamiento del nivel
/// </summary>
public class LevelController : Singleton<LevelController>
{
    [Header("Contador de nivel")]
    [SerializeField] Text levelCountText;

    [Header("Controladores")]
    [SerializeField] NumberGenerator numberGenerator;
    [SerializeField] ScoreControl scoreControl;
    [SerializeField] TextControl textControl;

    [Header("Botones")]
    [SerializeField] List<GameObject> buttonList;

    [Header("Opciones incorrectas")]
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

    /// <summary>
    /// Genera un nuevo nivel
    /// </summary>
    private void GenerateLevel() 
    {
        levelCount++;
        incorrectNumbers.Clear();
        failsInLevel = 0;

        correctNumber = numberGenerator.GenerateRandomNumber();

        //Por cada opcion incorrecta (una menos que el numero de botones) genera otro numero aleatorio distinto
        int i = 0;
        while (i < incorrectOptionsCount) 
        {
            int incorrectNumber = numberGenerator.GenerateRandomNumber();
            
            if (incorrectNumber != correctNumber && !incorrectNumbers.Contains(incorrectNumber)) 
            {
                incorrectNumbers.Add(incorrectNumber);
                ++i;
            }
                
        }

        //Se genera el texto del numero correcto
        string textNumber = numberGenerator.GenerateNumberText(correctNumber);
        textNumber.Trim();

        textControl.NumberTextString = char.ToUpper(textNumber[0]) + textNumber.Substring(1);

        //Asigna un indice aleatorio dentro de la lista de botones donde se coloca la respuesta correcta, el rango es exclusivo en el maximo por eso +1
        int correctNumberPlace = Random.Range(0, incorrectOptionsCount+1);

        int buttonListCount = 0;
        int incorrectNumberCount = 0;

        //Para cada botón se asigna un metodo distinto al evento de pulsado dependiendo si contiene el numero correcto o no
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

    /// <summary>
    /// Comportamiento de la respuesta correcta
    /// </summary>
    private void CorrectAnswer() 
    {
        scoreControl.IncreaseSucessCount();

        //Se simula que se han pulsado el resto de botones
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

    /// <summary>
    /// Comportamiento de la respuesta incorrecta
    /// </summary>
    private void IncorrectAnswer() 
    {
        failsInLevel++;
        scoreControl.IncreaseFailCount();

        if (failsInLevel == incorrectOptionsCount) 
        {
            //Se simula que se han pulsado el resto de botones
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