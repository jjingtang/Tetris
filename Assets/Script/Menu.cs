using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void goMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void designInnovation()
    {
        //Debug.Log("load design innovation scene");
        SceneManager.LoadScene("DesignInnovation");
    }
    public void quitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
