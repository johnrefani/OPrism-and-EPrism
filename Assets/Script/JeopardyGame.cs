using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class JeopardyGame : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject instructionPanel;
    public GameObject contextPanel;
    public GameObject questionPanel;
    public GameObject hintPanel;
    public GameObject solutionPanel;

    private int hintsShown = 0;
    [Header("Score To Reach")]
    public int scoretoReach;

    [Header("Question Elements")]
    public TMP_Text questionText;
    public Image questionImage;
    public Button answerButton1;
    public Button answerButton2;
    public Button answerButton3;

    public TMP_Text answerText1;
    public TMP_Text answerText2;
    public TMP_Text answerText3;

    public Image answerImage1;
    public Image answerImage2;
    public Image answerImage3;

    [Header("Hint Elements")]
    public TMP_Text hintText;
    public Image hintImage;
    public GameObject hintRawImage;
    public VideoPlayer hintVideoPlayer;
    

    [Header("Solution Elements")]
    public Image solutionImage;
    public GameObject solutionRawImage;
    public TMP_Text solutionText;
    public VideoPlayer solutionVideoPlayer;
    

    [Header("Scores")]
    public TMP_Text trackedScoreText, scoreText;

    private string currentQuestionKey;
    private int score;

    [Header("Question Database")]
    public QuestionData questionDatabase;

    private Color disabledColor = new Color32(226, 219, 255, 255);
    private Color disabledAnswerColor = new Color32(172, 10, 13, 255);

    private Vector3 originalSolutionImagePosition;
    private Vector3 originalSolutionRawImagePosition;

    [Header("Pop Up")]
    public GameObject PopUp;


    private int value = 0;

    void Awake()
    {

        LoadScore();
        string sceneName = SceneManager.GetActiveScene().name;

        int opened = PlayerPrefs.GetInt("Accessed_" + sceneName);
        Debug.Log(opened.ToString());
        if (opened == 0)
        {
            Context();

        }
        else
        {
            CloseInstruction();
        }

    }
    void Start()
    {
        InitializeButtonStates();
        string sceneName = SceneManager.GetActiveScene().name;

        PlayerPrefs.SetInt("Accessed_" + sceneName, 1);
        PlayerPrefs.Save();

        value = 0;

    }

    public void Context()
    {
        contextPanel.SetActive(true);
        instructionPanel.SetActive(false);
        mainPanel.SetActive(false);
    }

    public void CloseContext()
    {
        contextPanel.SetActive(false);
        instructionPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void CloseInstruction()
    {

        instructionPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OnQuestionButtonClicked(string questionKey)
    {
        SetQuestion(questionKey);
        questionPanel.SetActive(true);
        hintPanel.SetActive(false);
    }

    public void ActiveHintPanel()
    {
        questionPanel.SetActive(false);
        hintPanel.SetActive(true);
        hintVideoPlayer.Prepare();
        hintVideoPlayer.Play();
    }

    public void ActiveQuestionPanel()
    {
        questionPanel.SetActive(true);
        hintPanel.SetActive(false);
        hintVideoPlayer.Stop();
    }

    public void ActiveMainPanel()
    {
        questionPanel.SetActive(false);
        hintPanel.SetActive(false);
        solutionPanel.SetActive(false);
        answerButton1.interactable = true;
        answerButton2.interactable = true;
        answerButton3.interactable = true;
        solutionVideoPlayer.Stop();
    }

    public void SetQuestion(string questionKey)
    {
        if (questionDatabase.questions.ContainsKey(questionKey))
        {
            currentQuestionKey = questionKey;
            var (question, questionType, answers, answerType, correctIndex, choicesCount, hintCount, _, _, _, _, _, _, _) = questionDatabase.questions[questionKey];

            // Disable the question button and save its state
            DisableQuestionButton(questionKey);

            // Reset CanvasGroup interactable for all buttons before setting the question
            ResetButtonInteractable(answerButton1);
            ResetButtonInteractable(answerButton2);
            ResetButtonInteractable(answerButton3);

            if (questionType == "text")
            {
                questionText.text = question;
                questionText.gameObject.SetActive(true);
                questionImage.gameObject.SetActive(false);
            }
            else if (questionType == "image")
            {
                Sprite questionSprite = Resources.Load<Sprite>(question);
                if (questionSprite != null)
                {
                    questionImage.sprite = questionSprite;
                    questionImage.gameObject.SetActive(true);
                    questionText.gameObject.SetActive(false);
                }
                else
                {
                    Debug.LogError("Question image not found: " + question);
                }
            }



            answerButton1.gameObject.SetActive(true);
            answerButton2.gameObject.SetActive(true);
            answerButton3.gameObject.SetActive(choicesCount == 3);

            if (answerType == "text")
            {
                // Set text answers and hide image components
                answerText1.text = answers[0];
                answerText2.text = answers[1];
                answerText3.text = answers[2];

                answerText1.gameObject.SetActive(true);
                answerText2.gameObject.SetActive(true);
                answerText3.gameObject.SetActive(true);

                answerImage1.gameObject.SetActive(false);
                answerImage2.gameObject.SetActive(false);
                answerImage3.gameObject.SetActive(false);
            }
            else if (answerType == "image")
            {
                // Load and set image answers, and hide text components
                SetAnswerImage(answerImage1, answers[0]);
                SetAnswerImage(answerImage2, answers[1]);
                SetAnswerImage(answerImage3, answers[2]);

                answerText1.gameObject.SetActive(false);
                answerText2.gameObject.SetActive(false);
                answerText3.gameObject.SetActive(false);

                answerImage1.gameObject.SetActive(true);
                answerImage2.gameObject.SetActive(true);
                answerImage3.gameObject.SetActive(true);
            }

            // Show the question panel and hide the hint panel
            questionPanel.SetActive(true);
            hintPanel.SetActive(false);
            solutionPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Question Key does not exist");
        }
    }

    private void ResetButtonInteractable(Button button)
    {
        CanvasGroup canvasGroup = button.GetComponent<CanvasGroup>();

        // If a CanvasGroup exists, reset its interactability and opacity
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1.0f;  // Fully opaque
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;  // Enable interaction with button and its children
        }
        else
        {
            Debug.LogWarning("No CanvasGroup found on button: " + button.name);
        }

        // Reset button color to normal
        ColorBlock colorBlock = button.colors;
        colorBlock.disabledColor = new Color32(255, 255, 255, 255);  // Default color when enabled
        button.colors = colorBlock;
    }

    private void SetAnswerImage(Image imageComponent, string imageName)
    {
        if (!string.IsNullOrEmpty(imageName))
        {
            Sprite answerSprite = Resources.Load<Sprite>(imageName);
            if (answerSprite != null)
            {
                imageComponent.sprite = answerSprite;
            }
            else
            {
                Debug.LogError("Answer image not found: " + imageName);
            }
        }
    }


    private void DisplayHint(string hintType, string hintContent)
    {
        hintPanel.SetActive(true);
        hintText.gameObject.SetActive(false);
        hintImage.gameObject.SetActive(false);
        hintRawImage.gameObject.SetActive(false);
        hintVideoPlayer.gameObject.SetActive(false);
        //videoPlayer.Stop();

        switch (hintType)
        {
            case "text":
                hintText.text = hintContent;
                hintText.gameObject.SetActive(true);
                break;
            case "image":
                // Load the image from Resources folder
                Sprite hintSprite = Resources.Load<Sprite>(hintContent);
                if (hintSprite != null)
                {
                    hintImage.sprite = hintSprite;
                    hintImage.gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogError("Image not found: " + hintContent);
                }
                break;
            case "video":
                string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, hintContent);
                hintRawImage.gameObject.SetActive(true);
                hintVideoPlayer.gameObject.SetActive(true);
                hintVideoPlayer.url = videoPath;
                hintVideoPlayer.Prepare();
                hintVideoPlayer.Play();

                break;
        }
    }

    public void OnAnswerButtonClicked(int buttonIndex)
    {
        questionPanel.SetActive(false);
        hintPanel.SetActive(false);

        var (_, _, _, _, correctIndex, _, _, hint1Type, hint1Content, hint2Type, hint2Content, solutionType, solutionContent, solutionDescription) = questionDatabase.questions[currentQuestionKey];

        // Check if the selected answer is correct
        if (buttonIndex == correctIndex)
        {
            // Correct answer: Add points
            int points = int.Parse(currentQuestionKey.Split('_')[1]);
            score += points;
            // Display solution
            DisplaySolution(solutionType, solutionContent, solutionDescription);

            // Reset hints shown counter for the next question
            hintsShown = 0;
        }
        else
        {
            // Incorrect answer: Deduct points
            int points = int.Parse(currentQuestionKey.Split('_')[1]);
            //score -= points;  // Deduct the same points that the question is worth
            score -= 50;

            // Show the appropriate hint based on the number of hints shown
            if (hintsShown == 0)
            {
                DisplayHint(hint1Type, hint1Content);
                hintsShown++;
            }
            else if (hintsShown == 1)
            {
                DisplayHint(hint2Type, hint2Content);
                hintsShown++;
            }

            // Disable the answer button if incorrect
            DisableAnswerButton(buttonIndex);
        }

        // Update the score
        UpdateScore();

        // Check if the score has reached the threshold to unlock the button
        CheckAndUnlockFeature();
    }

    private void DisableAnswerButton(int buttonIndex)
    {
        Button answerButton = null;

        // Determine which answer button to disable
        switch (buttonIndex)
        {
            case 0:
                answerButton = answerButton1;
                break;
            case 1:
                answerButton = answerButton2;
                break;
            case 2:
                answerButton = answerButton3;
                break;
        }

        // Check if the answer button is not null
        if (answerButton != null)
        {
            // Disable the button
            answerButton.interactable = false;

            // Change the button's disabled color to #AC0A0D
            ColorBlock cb = answerButton.colors;
            cb.disabledColor = new Color32(172, 10, 13, 255); // #AC0A0D
            answerButton.colors = cb;

            // Get the CanvasGroup component if present
            CanvasGroup canvasGroup = answerButton.GetComponent<CanvasGroup>();

            // If CanvasGroup doesn't exist, add one
            if (canvasGroup == null)
            {
                canvasGroup = answerButton.gameObject.AddComponent<CanvasGroup>();
            }

            // Set the opacity of the button and its children
            canvasGroup.alpha = 0.5f;  // 0 = fully transparent, 1 = fully opaque

            // Optionally, set interactable to false on the CanvasGroup for all children (also disables child components like buttons or text)
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }




    public void OnHint1ButtonClicked()
    {
        if (questionDatabase.questions.TryGetValue(currentQuestionKey, out var questionData))
        {
            DisplayHint(questionData.hint1Type, questionData.hint1Content);
        }
    }

    public void OnHint2ButtonClicked()
    {
        if (questionDatabase.questions.TryGetValue(currentQuestionKey, out var questionData))
        {
            DisplayHint(questionData.hint2Type, questionData.hint2Content);
        }
    }

    private void DisplaySolution(string solutionType, string solutionContent, string solutionDescription)
    {

        // Store the original positions if they are not set yet
        if (originalSolutionImagePosition == Vector3.zero)
        {
            originalSolutionImagePosition = solutionImage.transform.position;
            originalSolutionRawImagePosition = solutionRawImage.transform.position;
        }

        solutionImage.gameObject.SetActive(false);
        solutionRawImage.SetActive(false);
        solutionVideoPlayer.gameObject.SetActive(false);
        //solutionVideoPlayer.Stop();

        // Check if solutionDescription is empty and adjust Y position
        if (string.IsNullOrEmpty(solutionDescription))
        {
            solutionImage.transform.position = new Vector3(solutionImage.transform.position.x, originalSolutionImagePosition.y - 50, solutionImage.transform.position.z);
            solutionRawImage.transform.position = new Vector3(solutionRawImage.transform.position.x, originalSolutionRawImagePosition.y - 50, solutionRawImage.transform.position.z);
        }

        switch (solutionType)
        {
            case "image":
                // Load the image from Resources folder
                Sprite solutionSprite = Resources.Load<Sprite>(solutionContent);
                if (solutionContent != null)
                {
                    solutionImage.sprite = solutionSprite;
                    solutionRawImage.SetActive(false);
                    solutionImage.gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogError("Image not found: " + solutionContent);
                }
                break;
            case "video":

                string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, solutionContent);

                solutionRawImage.SetActive(true);
                solutionVideoPlayer.gameObject.SetActive(true);
                solutionVideoPlayer.url = videoPath;
                solutionVideoPlayer.Prepare();
                solutionVideoPlayer.Play();
                break;
        }


        solutionText.text = solutionDescription;
        solutionPanel.SetActive(true);
    }

private void UpdateScore()
    {
        // Update the score display in the UI
        scoreText.text = "Score: " + score.ToString();
        trackedScoreText.text = score.ToString();

        string sceneName = SceneManager.GetActiveScene().name;
        // Save the score using the current scene name
        PlayerPrefs.SetInt(sceneName + "_Score", score);
        PlayerPrefs.Save();
        Debug.Log("Score: " + score);


    }

    private void LoadScore()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        // Load the score based on the current scene name
        if (PlayerPrefs.HasKey(sceneName + "_Score"))
        {
            score = PlayerPrefs.GetInt(sceneName + "_Score");
        }
        else
        {
            score = 0; // Default score if no saved score exists
        }

        // Update the score display
        scoreText.text = "Score: " + score.ToString();
        trackedScoreText.text = score.ToString();
        Debug.Log("Loaded Score: " + score);

    }

    private void DisableQuestionButton(string questionKey)
    {
        string buttonName = "Button_" + questionKey;
        Button questionButton = GameObject.Find(buttonName)?.GetComponent<Button>();
        if (questionButton != null)
        {
            questionButton.interactable = false;

            ColorBlock cb = questionButton.colors;
            cb.disabledColor = disabledColor;
            questionButton.colors = cb;


            PlayerPrefs.SetInt(buttonName, 0); // Save state as disabled
            PlayerPrefs.Save();
            Debug.Log(buttonName + " Disabled");
        }
        else
        {
            Debug.LogError("Button not found: " + buttonName);
        }
    }

    private void InitializeButtonStates()
    {

        foreach (var questionKey in questionDatabase.questions.Keys)
        {
            string buttonName = "Button_" + questionKey;
            Button questionButton = GameObject.Find(buttonName)?.GetComponent<Button>();
            if (questionButton != null)
            {
                int state = PlayerPrefs.GetInt(buttonName, 1); // Default state is enabled (1)
                questionButton.interactable = state == 1;


                ColorBlock cb = questionButton.colors;
                cb.disabledColor = disabledColor;
                questionButton.colors = cb;


                Debug.Log(buttonName + " state: " + state);
            }
            else
            {
                Debug.LogError("Button not found: " + buttonName);
            }
        }
    }


    // For Debug Only
    public void ResetAllButtonStates()
    {
   

        foreach (var questionKey in questionDatabase.questions.Keys)
        {
            string buttonName = "Button_" + questionKey;
            PlayerPrefs.SetInt(buttonName, 1); // Reset state to enabled
            Button questionButton = GameObject.Find(buttonName)?.GetComponent<Button>();
            if (questionButton != null)
            {
                questionButton.interactable = true;
            }
            else
            {
                Debug.LogError("Button not found: " + buttonName);
            }
        }
        PlayerPrefs.Save();

        string sceneName = SceneManager.GetActiveScene().name;
        score = PlayerPrefs.GetInt(sceneName + "_Score");
        score = 0;
        UpdateScore();
    }

    private void CheckAndUnlockFeature()
    {
        if (score >= scoretoReach)
        {
            // Retrieve the current value, add 1, and save it back to PlayerPrefs
            int currentAccessValue = PlayerPrefs.GetInt("Access Reached");
            currentAccessValue += 1;
            PlayerPrefs.SetInt("Access Reached", currentAccessValue);
            PlayerPrefs.Save();

            Debug.Log(currentAccessValue);

            // Show the popup
            ShowPopup();
        }
    }



    public void ShowPopup()
    {
        PopUp.SetActive(true);
    }


    public void HidePopup()
    {
        PopUp.SetActive(false);
    }

    
}