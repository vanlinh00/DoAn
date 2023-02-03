using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyBoxPanel : Singleton<LuckyBoxPanel>
{
    [SerializeField] Button _buttonClose;
    public GameObject[] arrayKeys;
    public List<LuckyBox> listBoxBtn;
    public GameObject Content;

    protected override void Awake()
    {
        LoadAllBoxBtn();
        base.Awake();
        _buttonClose.onClick.AddListener(CloseLuckyBoxPanel);
        DisplayKeys();
    }
    private void OnEnable()
    {
        RenewAllBoxBtn();
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
    public void LoadAllBoxBtn()
    {
        int countBoxBtn = Content.transform.childCount;

        for(int i=0;i<countBoxBtn;i++)
        {
            listBoxBtn.Add(Content.transform.GetChild(i).gameObject.GetComponent<LuckyBox>());
        }
    }
    public void RenewAllBoxBtn()
    {
        for(int i=0;i<listBoxBtn.Count;i++)
        {
            listBoxBtn[i].Renew();
        }
    }

}
