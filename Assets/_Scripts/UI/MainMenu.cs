using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private int sceneNumber;

    [SerializeField] private Button continueButton;

    [SerializeField] private GameObject warningWindow;

    [SerializeField] private string gameVersion;
    [SerializeField] private TMP_Text versionText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PositionX")) continueButton.interactable = true;
        else continueButton.interactable = false;

        versionText.text = gameVersion;
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void StartButton()
    {
        if (PlayerPrefs.HasKey("PositionX"))
        {
            warningWindow.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(sceneNumber);
        }
        
    }

    public void WarningButton()
    {
        SceneManager.LoadScene(sceneNumber);
        PlayerPrefs.DeleteKey("PositionX");
        PlayerPrefs.DeleteKey("PositionY");
        PlayerPrefs.DeleteKey("PositionZ");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
