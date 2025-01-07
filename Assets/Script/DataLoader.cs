using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [Header("Text Components")]
    public TMP_Text Name;
    public TMP_Text OPrism;
    public TMP_Text EPrism;
    public TMP_Text FinalExam;

    private string OPrismScoreKey = "OPrism_Score";
    private string EPrismScoreKey = "EPrism_Score";
    private string FinalExamScoreKey = "FinalExam_Score";


    void Start()
    {
        int OPrismInt = PlayerPrefs.GetInt(OPrismScoreKey);
        int EPrismInt = PlayerPrefs.GetInt(EPrismScoreKey);
        int FinalScoreInt = PlayerPrefs.GetInt(FinalExamScoreKey);

        if (OPrismInt == 0)
        {
            OPrism.text = "OPrism: Not Taken";
        }
        else
        {
            OPrism.text = "OPrism: " + OPrismInt.ToString() + " Points";
        }

        if (EPrismInt == 0)
        {
            EPrism.text = "EPrism: Not Taken";
        }
        else
        {
            EPrism.text = "EPrism: " + EPrismInt.ToString() + " Points";
        }

        if (FinalScoreInt == 0)
        {
            FinalExam.text = "Final Exam: Not Taken";
        }
        else
        {
            FinalExam.text = "Final Exam: " + FinalScoreInt.ToString() + " Points";
        }

        Name.text = PlayerPrefs.GetString("CharacterName");

    }
}
