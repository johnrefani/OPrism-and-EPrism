using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour
{
    public AudioClip buttonClickSound; // Assign your sound in the Inspector
    private AudioSource audioSource;

    private void Awake()
    {
        // Add or get an AudioSource component dynamically
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false; // Prevent automatic playback
    }

    public void PlayButtonSound()
    {
        if (buttonClickSound != null)
        {
            // Play the sound independently of the AudioSource's current state
            audioSource.PlayOneShot(buttonClickSound);
        }
        else
        {
            Debug.LogWarning("No button click sound assigned!");
        }
    }
}
