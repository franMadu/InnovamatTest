using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public delegate void PushButton();
    public event PushButton OnClickButton;

    [SerializeField] Text buttonText;

    private int numberInButton;
    private bool correctAnswer = false;
    private bool buttonPressed = false;

    private Animator animator;
    private Button button;


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

    public void ButtonInto() 
    {
        animator.SetBool("ButtonInto", true);
    }


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

    public void ResetParameters()
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        animator.SetBool("CorrectButton", false);
        animator.SetBool("ErrorButton", false);
        animator.SetBool("ButtonInto", false);

        buttonPressed = false;
    }

    public void ResolveLevel() 
    {
        if (correctAnswer)
        {
            animator.SetBool("CorrectButton", true);
        }
        else
        {
            animator.SetBool("ErrorButton", true);
        }
    }
}
