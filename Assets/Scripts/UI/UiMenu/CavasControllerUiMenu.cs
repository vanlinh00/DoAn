using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CavasControllerUiMenu : Singleton<CavasControllerUiMenu>
{
    [SerializeField] GameObject _mainUi;
    [SerializeField] GameObject _shopUi;
    [SerializeField] GameObject _rankUi;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _luckyPanel;
    [SerializeField] GameObject _mapUi;

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        //   DataPlayer a = new DataPlayer();
        MusicController.instance.OnPlayAudio(SoundType.mainmenu);

    }
    public void SetActiveLuckyPanel()
    {
        _mapUi.SetActive(false);
        _player.SetActive(false);
        _mainUi.SetActive(true);
        _shopUi.SetActive(false);
        _luckyPanel.SetActive(true);
    }
    public void DeActiveLuckyPanel()
    {
        _luckyPanel.SetActive(false);
        _player.SetActive(true);
    }
    public void SetActiveShopUi()
    {
        _mapUi.SetActive(false);
        _player.SetActive(false);
        _mainUi.SetActive(false);
        _shopUi.SetActive(true);
        _luckyPanel.SetActive(false);
    }
    public void SetActiveMainUi()
    {
        _mapUi.SetActive(false);
        _shopUi.SetActive(false);
        _player.SetActive(true);
        _mainUi.SetActive(true);
        _luckyPanel.SetActive(false);

    }
  
    public void OpenMapUi()
    {
        _shopUi.SetActive(false);
        _player.SetActive(false);
        _mainUi.SetActive(false);
        _luckyPanel.SetActive(false);
        _mapUi.SetActive(true);
    }

}
