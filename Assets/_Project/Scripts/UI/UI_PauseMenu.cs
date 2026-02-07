using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private UnityEvent<float> _onSensitivityChange;

    private float _mouseSens;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pauseMenuPanel.activeSelf)
        {
            _mouseSens = PlayerPrefs.GetFloat("MouseSensitivity");

            _pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            PlayerPrefs.SetFloat("MouseSensitivity", 0f);
            _onSensitivityChange.Invoke(0f);
        }
    }

    public void OnClickResumeGame()
    {
        _pauseMenuPanel.SetActive(!_pauseMenuPanel.activeSelf);
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PlayerPrefs.SetFloat("MouseSensitivity", _mouseSens);
        _onSensitivityChange.Invoke(_mouseSens);
    }

    public void OnClickOptions()
    {
        _optionsPanel.SetActive(!_optionsPanel.activeSelf);
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
