using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla el comportamiento de los botones
/// </summary>
public class ButtonControl : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] Text buttonText;

    private int numberInButton;
    private bool correctAnswer = false;
    private bool buttonPressed = false;

    private Animator animator;
    private Button button;

    public delegate void PushButton();
    public event PushButton OnClickButton;

    public int NumberInButton { get => numberInButton; set => numberInButton = value; }
    public bool CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
    public bool ButtonPressed { get => buttonPressed; set => buttonPressed = value; }

    public void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();

        button.interactable = false;
    }

    public void Update()
    {
        buttonText.text = NumberInButton.ToString();
    }

    /// <summary>
    /// Habilita la animacion de entrada de los botones
    /// </summary>
    public void ButtonInto() 
    {
        animator.SetBool("ButtonInto", true);
    }

    /// <summary>
    /// Acción a realizar cuando se pulsa un botón, se simula el click cuando se quiere imitar el comportamiento sin afectar a la puntuación
    /// </summary>
    /// <param name="clickSimulate"></param>
    public void ClickButton(bool clickSimulate) 
    {
        button.interactable = false;

        animator.SetBool("ButtonInto", false);

        if (correctAnswer)
        {
            animator.SetBool("CorrectButton", true);
        }
        else 
        {
            animator.SetBool("ErrorButton", true);
        }

        if (!clickSimulate)
        {
            buttonPressed = true;
            OnClickButton();
        }
    }

    /// <summary>
    /// Restituye los valores iniciales del botón para iniciar un nuevo nivel
    /// </summary>
    public void ResetParameters()
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        animator.SetBool("CorrectButton", false);
        animator.SetBool("ErrorButton", false);
        animator.SetBool("ButtonInto", false);

        buttonPressed = false;
    }
}