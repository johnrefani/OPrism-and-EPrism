using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAll : MonoBehaviour
{
   
    public void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("All PlayerPrefs have been cleared.");


        StartCoroutine(ReloadSceneAfterDelay(7.0f));
    }

  
    private IEnumerator ReloadSceneAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Splash");
    }
}
