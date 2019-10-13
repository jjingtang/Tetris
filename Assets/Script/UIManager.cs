using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool isEnd = false;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public static UIManager Instacnce;
    public Text txtScore;
    public int intScore=0;
    public Text txtTime;   //time Label
    public Slider sliderTime;
    public GameObject gameObjectParticle;

    public void PlayParticle()
    {
        //gameObjectParticle.GetComponent<ParticleSystem>().Play();
        gameObjectParticle.SetActive(true);
    }

    public void UpdateSliderTime(int intCur, int intMax)
    {
        if (sliderTime != null)
        {
            //Debug.Log("intCur" + intCur + "intMax="+ intMax);
            sliderTime.value = (float)intCur / (float)intMax;
            //Debug.Log("sliderTime.value="+sliderTime.value);
        }
    }

    public void UpdateTxtTime(string str)
    {
        if (txtTime != null)
        {
            txtTime.text = "" + str;
        }
    }

    public void UpdateTxtScore()
    {
        if (GameManager._instance.scene.name == "DesignInnovation")
        {
            txtScore.text = "" + intScore;
        }
    }

    void Awake()
    {
        Instacnce = this;
    }

    public void GameOver()
    {
        if (GameManager._instance.scene.name == "DesignInnovation")
        {
            Sound._instance.PlayAudioByName("GameOver");
        }
        isEnd = true;
        gameOverUI.SetActive(true);
    }

    public void GameWin()
    {
        if (GameManager._instance.scene.name == "DesignInnovation")
        {
            Sound._instance.PlayAudioByName("Win");
        }
        isEnd = true;
        gameWinUI.SetActive(true);
        UIManager.Instacnce.PlayParticle();
    }
}
