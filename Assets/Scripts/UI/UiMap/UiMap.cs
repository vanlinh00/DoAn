using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMap : MonoBehaviour
{
    public Button comeback;
    public GameObject mainPanel;

    //public Button map1Btn;
    //public Button map2Btn;
    //public Button map3Btn;

    //private void Awake()
    //{
    //    comeback.onClick.AddListener(ComeBackMenu);
    //    map1Btn.onClick.AddListener(OpenMap1);
    //    map2Btn.onClick.AddListener(OpenMap2);
    //    map3Btn.onClick.AddListener(OpenMap3);
    //}
    //public void ComeBackMenu()
    //{
    //    CavasControllerUiMenu._instance.SetActiveMainUi();
    //}
    //public void OpenMap1()
    //{
    //    SceneManager.LoadScene(1);
    //}
    //public void OpenMap2()
    //{
    //    SceneManager.LoadScene(2);
    //}
    //public void OpenMap3()
    //{
    //    SceneManager.LoadScene(3);
    //}
    public List<SelectLevelBtn> listSelectLevel;
    public Vector3 lastMouse;
    public Vector3 currentMouse;
    private void OnEnable()
    {
        LevelProgress();
    }
    void LevelProgress()
    {
        int CurrentLevel = 3-1;
        for(int i=0;i<listSelectLevel.Count;i++)
        {
            if(i<CurrentLevel)
            {
                listSelectLevel[i].Init(true, (i + 1).ToString(), 2);
            }
            else
            {
                listSelectLevel[i].Init(false, (i + 1).ToString(), 0);
            }

        }
    }
    private void Update()
    {
        currentMouse = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))
        {
            lastMouse = currentMouse;
        }
        if(Input.GetMouseButton(0))
        {
            float distance2Pos = lastMouse.x - currentMouse.x;
            if (distance2Pos!=0)
            {
                Vector3 targetPos = new Vector3(mainPanel.transform.localPosition.x + distance2Pos/50, mainPanel.transform.localPosition.y, 0f);
                mainPanel.GetComponent<RectTransform>().localPosition = targetPos;
            }

        }
    }
}
