using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelBtn : MonoBehaviour
{
    public Image bgImg;

    public Text levelTxt;
    public Color green;
    public Color white;

    public Image LineNextLevel;
    public PerformanceLevel performanceLevel;
    public Button mapSelectBtn;
    private void Awake()
    {
        mapSelectBtn.onClick.AddListener(LoadMap);
    }
    public void Init(bool IsPassed,string LevelTxt,int CountStar)
    {
        if(IsPassed)
        {
            levelTxt.color = white;
            bgImg.gameObject.SetActive(true);
            LineNextLevel.gameObject.SetActive(true);
        }
        else
        {
            LineNextLevel.gameObject.SetActive(false);
            levelTxt.color = green;
            bgImg.gameObject.SetActive(false);
        }
        levelTxt.text = LevelTxt;
        performanceLevel.CompleteStar(CountStar);
    }    
    public void LoadMap()
    {
        SceneManager.LoadScene(int.Parse(levelTxt.text));
    }
}
