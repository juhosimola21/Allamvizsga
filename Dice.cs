﻿using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;
    [SerializeField] internal GameControl control;
    [SerializeField] Transform quizPanel;
    [SerializeField] QuizManager quizManager;
    private GameControl player;
   // public static GameObject player2;

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
	}

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;

        quizPanel.gameObject.SetActive(true);

        quizManager.generateQuestion();

        //quizManager.options[valasztottOpcio].GetComponent<AnswerScript>().isCorrect == true

        while(quizManager.kivalasztottOpcio == -1)
        {
            yield return new WaitForSeconds(0.05f);
        }

        Debug.Log("Kivalasztott opcio = " + quizManager.kivalasztottOpcio);

        yield return new WaitForSeconds(1f);

        quizPanel.gameObject.SetActive(false);

        if (quizManager.options[quizManager.kivalasztottOpcio].GetComponent<AnswerScript>().isCorrect)
        {
            

            if (whosTurn == 1)
            {
                //GameControl.MovePlayer(1);
                control.MovePlayer(1);
            }
            else if (whosTurn == -1)
            {
                //GameControl.MovePlayer(2);
                control.MovePlayer(2);
            }
        }

        quizManager.kivalasztottOpcio = -1;

        whosTurn *= -1;
        coroutineAllowed = true;
    }
}
