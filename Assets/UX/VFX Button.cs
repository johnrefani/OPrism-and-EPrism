using UnityEngine;

public class VFXButton : MonoBehaviour
{
    // Singleton instance
    public static VFXButton Instance;

    private bool hasBeenPressed = false;

    private void Awake()
    {
        // Ensure only one instance of VFXButton exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject across scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    public void Play()
    {
        if (!hasBeenPressed)
        {
            hasBeenPressed = true;
            // Add your play logic here, e.g., play a sound or visual effect
        }
    }
}
