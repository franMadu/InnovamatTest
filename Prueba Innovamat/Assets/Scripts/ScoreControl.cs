using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    [SerializeField] Text sucessText;
    [SerializeField] Text failText;

    private int sucessCount = 0;
    private int failCount = 0;

    public int SucessCount { get => sucessCount; set => sucessCount = value; }
    public int FailCount { get => failCount; set => failCount = value; }

    public void Update()
    {
        sucessText.text = "Aciertos: " + sucessCount;
        failText.text = "Fallos: " + failCount;
    }
}
