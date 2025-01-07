using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuizManager : MonoBehaviour
{
    [Header("Question Component")]
    public List<QuestionAnswer> QA;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestionText;

    [Header("Panels")]
    public GameObject gameOver;
    public GameObject quizPanel;
    public GameObject reminderPanel;

    [Header("Score Component")]
    public TMP_Text ScoreText;
    public TMP_Text PageNumberText;
    public int scoreCount;
    int totalQuestions = 0;
    public int answeredQuestions;

    private bool optionsInteractable = true;


    [Header("Audio Source")]
    public AudioSource AudioCorrect;
    public AudioSource AudioWrong;

    [Header("Timer Component")]
    public float timerDuration = 180f; // 3 minutes
    private float timer;
    public TMP_Text TimerText;

    void Start()
    {
        

        totalQuestions = QA.Count;
        gameOver.SetActive(false);
        quizPanel.SetActive(false);
        reminderPanel.SetActive(true);
        answeredQuestions = 0; // Initialize current question to the first question
        generateQuestion();


    }

    void Update()
    {
        if (quizPanel.activeSelf && timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();

            if (timer <= 0)
            {
                timer = 0;
                GameOver();
            }
        }
    }

    public void CloseReminder()
    {
        gameOver.SetActive(false);
        quizPanel.SetActive(true);
        reminderPanel.SetActive(false);

        StartTimer(); // Start the timer when the reminder is closed
    }

    void StartTimer()
    {
        timer = timerDuration;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void correct()
    {

        AudioCorrect.Play();
        scoreCount += 500;
        QA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());


    }

    public void wrong()
    {
        AudioWrong.Play();
        QA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }

    IEnumerator WaitForNext()
    {
        SetOptionsInteractable(false); // Disable options immediately

        yield return new WaitForSeconds(3);

        if (QA.Count > 0)
        {
            answeredQuestions++;
            generateQuestion();
        }
        else
        {
            GameOver(); // No more questions, end the game
        }

        yield return new WaitForSeconds(0.1f); // Small delay to ensure the new question is generated

        SetOptionsInteractable(true); // Enable options after generating the new question
    }

    void SetOptionsInteractable(bool interactable)
    {
        foreach (var option in options)
        {
            option.GetComponent<Button>().interactable = interactable;
        }
    }

    public void Retry()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        quizPanel.SetActive(false);
        gameOver.SetActive(true);

        string name = PlayerPrefs.GetString("CharacterName");

        
        ScoreText.text = "Congratulations " + name + "!"+ "\n Your Final Score is: " + scoreCount;

        string sceneName = SceneManager.GetActiveScene().name;
        // Save the current score to PlayerPrefs with a unique key based on the scene
        PlayerPrefs.SetInt(sceneName + "_Score", scoreCount);
        PlayerPrefs.Save();


        
    }
    void SetAnswer()
    {
        int answerCount = QA[currentQuestion].Answers.Length;

        for (int i = 0; i < options.Length; i++)
        {
            if (i < answerCount)
            {
                options[i].SetActive(true); // Ensure the option is active if within the range of answers
                options[i].GetComponent<Button>().interactable = optionsInteractable; // Set interactable based on the flag

                options[i].GetComponent<AnswersScript>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QA[currentQuestion].Answers[i];

                //Changing color when get clicked.
                options[i].GetComponent<Image>().color = options[i].GetComponent<AnswersScript>().startColor;

                // Set the correct answer flag
                if (QA[currentQuestion].CorrectAnswer == i + 1)
                {
                    options[i].GetComponent<AnswersScript>().isCorrect = true;
                }
            }
            else
            {
                options[i].SetActive(false); // Hide the option if not within the range of answers
            }
        }

        UpdatePageNumber();
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("Access Reached", 3);
        PlayerPrefs.Save();
    }


    public void generateQuestion()
    {
        if (QA.Count > 0)
        {
            currentQuestion = Random.Range(0, QA.Count);

            QuestionText.text = QA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver();
        }


    }

    void UpdatePageNumber()
    {
        PageNumberText.text = "Question " + (answeredQuestions + 1) + " / " + totalQuestions;
    }


}