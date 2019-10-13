using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    bool isEnd = false;
    public GameObject gameOverUI;
    public static UIManager Instacnce;

    void Start()
    {
        Instacnce = this;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        isEnd = true;
    }
}
