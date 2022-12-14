using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUiMenu : Singleton<MainUiMenu>
{
    [SerializeField] Button _btMiddleLeft;
    [SerializeField] Button _btMiddleRight;
    [SerializeField] Button _btShop;
    [SerializeField] Animator animator;
    [SerializeField] Button _btnLuckyBox;

    [SerializeField] Button _chooseMapBtn;
    public Text countCoin;
    public Text CountDiamond;
    protected override void Awake()
    {
        base.Awake();
        _btMiddleLeft.onClick.AddListener(NextAnimationl);
        _btMiddleRight.onClick.AddListener(NextAnimationr);
        _btShop.onClick.AddListener(OpenShop);
        _btnLuckyBox.onClick.AddListener(OpenLuckyBox);
        _chooseMapBtn.onClick.AddListener(CavasControllerUiMenu._instance.OpenMapUi);

        UpdateCoinsAndDiamonds();
    }
    public void UpdateCoinsAndDiamonds()
    {
        countCoin.text = DataPlayer.GetInforPlayer().countCoins.ToString();
        CountDiamond.text = DataPlayer.GetInforPlayer().countDiamond.ToString();

    }
    public void OpenLuckyBox()
    {
        CavasControllerUiMenu._instance.SetActiveLuckyPanel();
    }
    void OpenShop()
    {
        //  SoundManager.instance.OnPlayAudio(SoundType.ButtonBlip);
        CavasControllerUiMenu._instance.SetActiveShopUi();
        StateOut();

    }
    void StateOut()
    {
        animator.SetTrigger("OutMain");

    }
    void NextAnimationl()
    {
       // SoundManager.instance.OnPlayAudio(SoundType.ButtonBlip);
        ChangeAniPlayerUiMenu.instance.ChangeAnimaiton(true);

        if (ChangeAniPlayerUiMenu.instance.checkNextAnim == 0)
        {
            _btMiddleLeft.gameObject.SetActive(false);
        }
    }
    void NextAnimationr()
    {
     //   SoundManager.instance.OnPlayAudio(SoundType.ButtonBlip);
        ChangeAniPlayerUiMenu.instance.ChangeAnimaiton(false);

        if (ChangeAniPlayerUiMenu.instance.checkNextAnim != 0)
        {
            _btMiddleLeft.gameObject.SetActive(true);
        }

    }
   

}
