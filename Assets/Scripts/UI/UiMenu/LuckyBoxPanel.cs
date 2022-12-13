using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyBoxPanel : Singleton<LuckyBoxPanel>
{
    [SerializeField] Button _buttonClose;
    public GameObject[] arrayKeys;

    private void Awake()
    {
        base.Awake();
        _buttonClose.onClick.AddListener(CloseLuckyBoxPanel);
    }
    public void CloseLuckyBoxPanel()
    {
        CavasControllerUiMenu._instance.DeActiveLuckyPanel();
    }
    public void DisplayKeys()
    {
        int CountKey = DataPlayer.GetInforPlayer().countKeys;
        for (int i = 0; i < CountKey; i++)
        {
           arrayKeys[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        for(int i= CountKey;i<3;i++)
        {
            arrayKeys[i].transform.GetChild(0).gameObject.SetActive(true);
        }    
    }

}
