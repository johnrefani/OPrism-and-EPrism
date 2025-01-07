using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterName : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TMP_Text Placeholder;

    public void SetName()
    {
        string name = NameInputField.text;

        if (name == "")
        {
            Placeholder.text = "Enter your name here!";
            Placeholder.color = Color.red;
        }
        else
        {
            PlayerPrefs.SetString("CharacterName", name);
            PlayerPrefs.Save();
            StartCoroutine(LoadSceneWithDelay("Home"));
        
    }
        
    }

    public void SetOnboarding()
    {
        PlayerPrefs.SetInt("OnboardingStatus", 1);
        PlayerPrefs.Save();

    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(0.5f); // Delay for 0.5 seconds
        SceneManager.LoadScene(sceneName);
        Debug.Log(sceneName);
    }


}
