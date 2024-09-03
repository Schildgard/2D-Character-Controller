using UnityEngine;

public class ExitManager : MonoBehaviour
{
    // Manages the Application Exit Option
    [SerializeField] private GameObject pauseScreenPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowAndHidePauseScreen();
        }
    }
    public void ShowAndHidePauseScreen()
    {
       pauseScreenPanel.SetActive(!pauseScreenPanel.activeSelf);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
