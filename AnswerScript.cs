using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public void Answer()
    {
        //Debug.Log("Valasztott gomb: " + this.gameObject.name);

        quizManager.kivalasztottOpcio = (int)Char.GetNumericValue(this.gameObject.name[this.gameObject.name.Length - 1]) - 1; 

        if (isCorrect)
        {
            Debug.Log("Helyes válasz!");
            //quizManager.correct();
        }
        else
        {
            Debug.Log("Helytelen válasz!");
            //quizManager.correct();
        }
    }

}
