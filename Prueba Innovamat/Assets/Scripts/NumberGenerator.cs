using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que genera numeros aleatorios y los convierte a texto.
/// </summary>
public class NumberGenerator : MonoBehaviour
{
    [SerializeField] int minRandomValue = 0;
    [SerializeField] int maxRandomValue = int.MaxValue;

    /// <summary>
    /// Genera un numero aleatorio positivo
    /// </summary>
    /// <returns>int</returns>
    public int GenerateRandomNumber()
    {
        int randomNumber = UnityEngine.Random.Range(minRandomValue, maxRandomValue);

        return randomNumber;
    }

    /// <summary>
    /// Se obtiene el numero escrito con letras
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public string GenerateNumberText(int number) 
    {
        string numberText = "";

        if (number > 0)
        {
            numberText = "menos ";
        }

        if (number == 0)
        {
            numberText = "cero";
        }
        else if (number == 1)
        {
            numberText = "uno";
        }
        else if (number == 2)
        {
            numberText = "dos";
        }
        else if (number == 3)
        {
            numberText = "tres";
        }
        else if (number == 4)
        {
            numberText = "cuatro";
        }
        else if (number == 5)
        {
            numberText = "cinco";
        }
        else if (number == 6)
        {
            numberText = "seis";
        }
        else if (number == 7)
        {
            numberText = "siete";
        }
        else if (number == 8)
        {
            numberText = "ocho";
        }
        else if (number == 9)
        {
            numberText = "nueve";
        }
        else if (number == 10)
        {
            numberText = "diez";
        }
        else if (number == 11)
        {
            numberText = "once";
        }
        else if (number == 12)
        {
            numberText = "doce";
        }
        else if (number == 13)
        {
            numberText = "trece";
        }
        else if (number == 14)
        {
            numberText = "catorce";
        }
        else if (number == 15)
        {
            numberText = "quince";
        }
        else if (number < 20)
        {
            numberText = "dieci" + GenerateNumberText(number - 10);

            if (numberText.Equals("dieciseis"))
            {
                numberText = numberText.Replace("dieciseis", "dieciséis");
            }
        }
        else if (number == 20)
        {
            numberText = "veinte";
        }
        else if (number < 30)
        {
            numberText = "veinti" + GenerateNumberText(number - 20);

            if (numberText.Equals("veintidos"))
            {
                numberText = numberText.Replace("veintidos", "veintidós");
            }

            if (numberText.Equals("veintitres"))
            {
                numberText = numberText.Replace("veintitres", "veintitrés");
            }

            if (numberText.Equals("veintiseis"))
            {
                numberText = numberText.Replace("veintiseis", "veintiséis");
            }
        }
        else if (number == 30)
        {
            numberText = "treinta";
        }
        else if (number == 40)
        {
            numberText = "cuarenta";
        }
        else if (number == 50)
        {
            numberText = "cincuenta";
        }
        else if (number == 60)
        {
            numberText = "sesenta";
        }
        else if (number == 70)
        {
            numberText = "setenta";
        }
        else if (number == 80)
        {
            numberText = "ochenta";
        }
        else if (number == 90)
        {
            numberText = "noventa";
        }
        else if (number < 100)
        {
            double truncNumber = Math.Truncate(Convert.ToDouble(number / 10)) * 10;

            numberText = GenerateNumberText(Convert.ToInt32(truncNumber)) + " y " + GenerateNumberText(number % 10);
        }
        else if (number == 100)
        {
            numberText = "cien";
        }
        else if (number < 200)
        {
            numberText = "ciento " + GenerateNumberText(number - 100);
        }
        else if (number == 200 || number == 300 || number == 400 || number == 600 || number == 800)
        {
            double truncNumber = Math.Truncate(Convert.ToDouble(number / 100));

            numberText = GenerateNumberText(Convert.ToInt32(truncNumber)) + "cientos";
        }
        else if (number == 500)
        {
            numberText = "quinientos";
        }
        else if (number == 700)
        {
            numberText = "setecientos";
        }
        else if (number == 900)
        {
            numberText = "novecientos";
        }
        else if (number < 1000)
        {
            double truncNumber = Math.Truncate(Convert.ToDouble(number / 100)) * 100;

            numberText = GenerateNumberText(Convert.ToInt32(truncNumber)) + " " + GenerateNumberText(number % 100);
        }
        else if (number == 1000)
        {
            numberText = "mil";
        }
        else if (number < 2000)
        {
            numberText = "mil " + GenerateNumberText(number % 1000);
        }
        else if (number < 1000000)
        {
            double truncNumber = Math.Truncate(Convert.ToDouble(number / 1000));

            string textAux = GenerateNumberText(Convert.ToInt32(truncNumber));

            if (textAux.Contains("uno"))
            {
                textAux = textAux.Substring(0, textAux.Length - 1);
            }

            numberText = textAux + " mil";
            
            if ((number % 1000) > 0)
            {
                numberText = numberText + " " + GenerateNumberText(number % 1000);
            }
        }
        else if (number == 1000000)
        {
            numberText = "un millón";
        }
        else if (number < 2000000)
        {
            numberText = "un millón " + GenerateNumberText(number % 1000000);
        }
        else 
        {
            double truncNumber = Math.Truncate(Convert.ToDouble(number / 1000000));

            string textAux = GenerateNumberText(Convert.ToInt32(truncNumber));

            if (textAux.Contains("uno"))
            {
                textAux = textAux.Substring(0, textAux.Length - 1);
            }

            numberText = textAux + " millones";

            if ((number - Convert.ToInt32(truncNumber) * 1000000) > 0)
            {
                numberText = numberText + " " + GenerateNumberText(number - Convert.ToInt32(truncNumber) * 1000000);
            }

        }

        return numberText;
    
    }
}
