using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMap : MonoBehaviour
{
    public Button comeback;

    public Button map1Btn;
    public Button map2Btn;
    public Button map3Btn;

    private void Awake()
    {
        comeback.onClick.AddListener(ComeBackMenu);
        map1Btn.onClick.AddListener(OpenMap1);
        map2Btn.onClick.AddListener(OpenMap2);
        map3Btn.onClick.AddListener(OpenMap3);
    }
    public void ComeBackMenu()
    {
        CavasControllerUiMenu._instance.SetActiveMainUi();
    }
    public void OpenMap1()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenMap2()
    {
        SceneManager.LoadScene(2);
    }
    public void OpenMap3()
    {
        SceneManager.LoadScene(3);
    }
}
