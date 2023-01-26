using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMap : MonoBehaviour
{
    public Button comeback;
    public GameObject mainPanel;
    public List<SelectLevelBtn> listSelectLevel;
    public Vector3 lastMouse;
    public Vector3 currentMouse;
    private void OnEnable()
    {
        LevelProgress();
    }
    void LevelProgress()
    {
        List<int> listStars = DataPlayer.GetInforPlayer().listCountStarLevel;
        for (int i = 0; i < listSelectLevel.Count; i++)
        {  
            listSelectLevel[i].Init(true, (i + 1).ToString(), listStars[i]);
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
