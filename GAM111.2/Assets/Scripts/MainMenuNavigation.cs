using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuNavigation : MonoBehaviour
{
    public string GameSceneName;

    public void PlayGame ()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
