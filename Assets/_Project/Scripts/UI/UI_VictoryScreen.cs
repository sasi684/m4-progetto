using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_VictoryScreen : MonoBehaviour
{

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
