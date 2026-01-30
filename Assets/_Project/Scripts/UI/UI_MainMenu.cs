using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;

    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnClickOptions()
    {
        _optionsPanel.SetActive(!_optionsPanel.activeSelf);
    }

    public void OnClickExitGame()
    {
        Debug.Log("Sei uscito dal gioco");
        Application.Quit();
    }

}
