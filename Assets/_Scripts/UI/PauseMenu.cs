using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Animator blackScreen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void ContinueGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pausePanel.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        blackScreen.SetTrigger("Fade In");
        Invoke("InvokedExit", 2f);
    }

    private void InvokedExit()
    {
        SceneManager.LoadScene(0);
    }
}
