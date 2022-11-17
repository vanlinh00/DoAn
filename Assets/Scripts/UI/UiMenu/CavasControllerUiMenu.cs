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

    void Start()
    {
     //   DataPlayer a = new DataPlayer();
      //  MusicManager.instance.OnPlayMusic(MusicType.MainMenu);
    }
    public void SetActiveShopUi()
    {
        _player.SetActive(false);
        _shopUi.SetActive(true);
    }


}
