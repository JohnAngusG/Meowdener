using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    bool muted = false;

    public void OnQuitButton()
    {
        Application.Quit();

    }

    public void OnMuteButton() {
        if (!muted)
        {
            SoundManager.Instance.StopMusic();
            muted = true;
        }
        else {
            SoundManager.Instance.PlayMusic();
            muted = false;
        }
        
    
    }

    public void OnResetButton()
    {
        string currScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currScene);

    }
}
