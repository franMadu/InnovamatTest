using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    private Text numberText;
    private Animator animator;

    private string numberTextString;

    public delegate void SpawnButton();
    public event SpawnButton SpawningButton;

    public string NumberTextString { get => numberTextString; set => numberTextString = value; }

    public void Awake()
    {
        animator = GetComponent<Animator>();
        numberText = GetComponent<Text>();
    }

    public void Update()
    {
        numberText.text = numberTextString;
    }

    public void FaceInText() 
    {
        animator.SetBool("NumberTextOut", false);
        animator.SetBool("NumberTextInto", true);

        Invoke("FaceOutText", 4.0f);
    }

    public void FaceOutText()
    {
        animator.SetBool("NumberTextInto", false);
        animator.SetBool("NumberTextOut", true);

        Invoke("SpawningButtonCalling", 2.0f);
    }

    public void SpawningButtonCalling() 
    {
        SpawningButton();
    }
}
