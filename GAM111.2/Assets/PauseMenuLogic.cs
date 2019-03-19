using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuLogic : MonoBehaviour
{
    public Canvas pauseMenuCanvas;
    public Image Selector;
    public Button[] navigationButtons;
    public PlayerMovement playerMovement;
    bool isPaused = false;
    bool[] isSelectingButton = new bool[2];
    void Start()
    {
        pauseMenuCanvas.gameObject.SetActive(false);
        isSelectingButton[0] = true;
        isSelectingButton[1] = false;
        playerMovement.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            ResumeGame();
        }
        if (isSelectingButton[0] && isPaused)
        {
            Selector.transform.position = navigationButtons[0].transform.position;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResumeGame();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isSelectingButton[0] = false;
                isSelectingButton[1] = true;
            }
        }
        else if (isSelectingButton[1] && isPaused)
        {
            Selector.transform.position = navigationButtons[1].transform.position;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SwitchToMainMenu();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isSelectingButton[0] = true;
                isSelectingButton[1] = false;
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuCanvas.gameObject.SetActive(true);
        isPaused = true;
        playerMovement.enabled = false; 
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.gameObject.SetActive(false);
        isPaused = false;
        playerMovement.enabled = true;
        Time.timeScale = 1;
    }

    public void SwitchToMainMenu ()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
