using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuetionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;

    public int kivalasztottOpcio = -1;
    private Button theButton, theButton2;
    private ColorBlock theColor;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        //QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
       for(int i=0; i<options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            //options[i].GetComponent<AnswerScript>().answerID = i;
            theButton = options[i].GetComponent<Button>();
            theColor = options[i].GetComponent<Button>().colors;
            theColor.pressedColor = Color.red;

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                theColor.pressedColor = Color.green;
                theButton.colors = theColor;
            }
            else
            {
                theColor.pressedColor = Color.red;
                theButton.colors = theColor;
            }
            
        }
    }

    public void generateQuestion()
    {
        currentQuestion = UnityEngine.Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }

}
