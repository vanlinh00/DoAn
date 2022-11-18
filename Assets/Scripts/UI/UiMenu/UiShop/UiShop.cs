using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiShop : Singleton<UiShop>
{
    [SerializeField] Button _quiteBg;
    [SerializeField] Button _quiteBtn;

    protected override void Awake()
    {
        _quiteBg.onClick.AddListener(CavasControllerUiMenu._instance.SetActiveMainUi);
        _quiteBtn.onClick.AddListener(CavasControllerUiMenu._instance.SetActiveMainUi);
    }
    
}
