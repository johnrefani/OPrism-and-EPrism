using UnityEngine;

public class showPanel : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource
    public GameObject panel1; // Reference to the first panel
    public GameObject panel2; // Reference to the second panel
    public GameObject panel3; // Reference to the third panel

    void Update()
    {
        // Check if either of the panels is active
        if (panel1.activeSelf || panel2.activeSelf || panel3.activeSelf)
        {
            PauseAudio();
        }
        else
        {
            PlayAudio();
        }
    }

    void PauseAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
