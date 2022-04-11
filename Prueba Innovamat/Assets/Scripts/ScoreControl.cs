using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla el comportamiento de la puntuación
/// </summary>
public class ScoreControl : Singleton<ScoreControl>
{
    [Header("Textos")]
    [SerializeField] Text sucessText;
    [SerializeField] Text failText;

    private int sucessCount = 0;
    private int failCount = 0;

    public void Update()
    {
        sucessText.text = "Aciertos: " + sucessCount;
        failText.text = "Fallos: " + failCount;
    }

    public void IncreaseSucessCount() 
    {
        sucessCount++;
    }

    public void IncreaseFailCount()
    {
        failCount++;
    }
}