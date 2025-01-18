using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mechanics : MonoBehaviour
{
    public GameObject helpPanel;
    public Sprite[] imageSet;
    public Image image;
    public Button previousButton;
    private int currentIndex = 0;
    void Start()
    {
        helpPanel.SetActive(false);
    }

    public void OpenHelp()
    {
        helpPanel.SetActive(true);
        currentIndex = 0;
        UpdateHelp(currentIndex);
        previousButton.interactable = false;

    }

    public void UpdateHelp(int index)
    {
        if (index >= 0 && currentIndex < imageSet.Length)
        {

            image.sprite = imageSet[index];
        }
    }
    public void Previous()
    {
        if ( currentIndex > 0)
        {
            currentIndex--;

            if (currentIndex == 0)
            {
                previousButton.interactable = false;
            }

            UpdateHelp(currentIndex);

        }
        
    }

    public void Next()
    {
        if (currentIndex < imageSet.Length - 1)
        {
            currentIndex++;
            previousButton.interactable = true;
            UpdateHelp(currentIndex);

        }
        else
        {
            helpPanel.SetActive(false);
        }
    }
}
