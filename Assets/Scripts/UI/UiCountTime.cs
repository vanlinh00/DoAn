using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiCountTime : Singleton<UiCountTime>
{
    public float currentTime;
    public int totalTime;
    public Text textTotalTime;
    void Start()
    {
        currentTime = 0;
        UpDateTime();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 1)
        {
            currentTime = 0;
            totalTime -= 1;
            UpDateTime();
            if (totalTime <= 0)
            {
                GameManager._instance.gamePlay.WinGame();
                return;
            }
        }
    }
    public void UpDateTime()
    {
        if (totalTime < 0)
            return;
        int a = totalTime / 60;
        int Residual = totalTime % 60;
        if (a > 0)
        {
            textTotalTime.text = a + ":" + Residual + "M";
        }
        else
        {
            textTotalTime.text = Residual + "S";
        }
    }
}
