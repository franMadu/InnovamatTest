using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla el comportamiento del texto
/// </summary>
public class TextControl : Singleton<TextControl>
{
    [Header("Componentes")]
    [SerializeField] Text numberText;
    [SerializeField] Animator animator;

    private string numberTextString;

    public delegate void SpawnButton();
    public event SpawnButton SpawningButton;

    public string NumberTextString { get => numberTextString; set => numberTextString = value; }

    public void Update()
    {
        numberText.text = numberTextString;
    }

    /// <summary>
    /// Animacion de faceIn del texto
    /// </summary>
    public void FaceInText() 
    {
        animator.SetBool("NumberTextOut", false);
        animator.SetBool("NumberTextInto", true);

        Invoke("FaceOutText", 4.0f);
    }

    /// <summary>
    /// Animacion de faceOut del texto
    /// </summary>
    public void FaceOutText()
    {
        animator.SetBool("NumberTextInto", false);
        animator.SetBool("NumberTextOut", true);

        Invoke("SpawningButtonCalling", 2.0f);
    }

    /// <summary>
    /// Lanza el evento para que se muestren los botones
    /// </summary>
    public void SpawningButtonCalling() 
    {
        SpawningButton();
    }
}