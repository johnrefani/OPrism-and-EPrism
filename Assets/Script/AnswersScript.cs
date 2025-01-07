using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class AnswersScript : MonoBehaviour
{
    public bool isCorrect = false;

    public QuizManager quizManager;



    public Color startColor;



    private void Start()
    {
        startColor = GetComponent<Image>().color;

    }

    public void Answer()
    {
        if (isCorrect)
        {

            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.correct();



        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();



        }

    }
}