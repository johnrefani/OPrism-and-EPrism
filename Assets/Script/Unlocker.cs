using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unlocker : MonoBehaviour
{
    public Button ButtonToUnlock;
    public Button ExamToUnlock;
    public TMP_Text Notice;
    public TMP_Text ExamNotice;
    public TMP_Text FinalScore;

    void Start()
    {
        int finalscore = PlayerPrefs.GetInt("Final Score");
        // Set initial states
        ButtonToUnlock.interactable = false;
        ExamToUnlock.interactable = false;
        FinalScore.gameObject.SetActive(false);
        Notice.gameObject.SetActive(true);
        ExamNotice.gameObject.SetActive(true);

        // Get the access level
        int access = PlayerPrefs.GetInt("Access Reached");
        Debug.Log(access.ToString());

        // Evaluate access level and update UI accordingly
        if (access >= 1)
        {
            ButtonToUnlock.interactable = true;
            Notice.gameObject.SetActive(false);
        }
        if (access >= 2)
        {
            ExamToUnlock.interactable = true;
            ExamNotice.gameObject.SetActive(false);
        }

        if (access >= 3)
        {
            
        }
    }
}
