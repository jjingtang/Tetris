using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    float sumTime = 180f;//total time
    float intTime = 0f;
    private float floatNormalSpeed = 0.5f;  //default speed
    public static GameManager _instance;
    public float FloatNormalSpeed { get => floatNormalSpeed; set => floatNormalSpeed = value; }
    public Scene scene;
    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();

        if (GameManager._instance.scene.name == "DesignInnovation")
        {
            intTime = sumTime;
            StartCoroutine(startCountDown());
        }
    }


    void AddSpeed(float intTime, float TotalTime)
    {
        float floatUnitTime = TotalTime / 3;

        //if the time remaining is 60 - 120 seconds
        if (intTime>= floatUnitTime && intTime < floatUnitTime*2)
        {
            floatNormalSpeed = 0.5f / 2;
            //double speed
        }

        //if the time remaining is 0-60 seconds
        if (intTime >= 0 && intTime < floatUnitTime)
        {
            floatNormalSpeed = 0.5f / 3;
            //triple speed
        }
    }


    //count down
    public IEnumerator startCountDown()
    {
        while (intTime >= 0 && !UIManager.Instacnce.isEnd)
        {
            if (intTime == 0)
            {   //if time is passed 3 mins, then game win
                Debug.Log("game win");
                UIManager.Instacnce.GameWin();
            }
            else
            {
                intTime--;
                AddSpeed(intTime, sumTime);
                UIManager.Instacnce.UpdateTxtTime("" + intTime); //UI update
                UIManager.Instacnce.UpdateSliderTime((int)intTime, (int)sumTime);
                //call every 1 seconds
                yield return new WaitForSeconds(1);
            }
        }
    }


 
}
