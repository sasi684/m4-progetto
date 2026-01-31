using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_DefeatScreen : MonoBehaviour
{
    
    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
