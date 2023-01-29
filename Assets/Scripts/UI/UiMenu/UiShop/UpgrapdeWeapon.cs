using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UpgrapdeWeapon : MonoBehaviour
{
    public Button quiteBtn;
    public Text levelGunTxt;
    public Text nameGunTxt;
    public Text tutorialTxt;

    public Image damageBar;
    public Image rateRireBar;
    public Image accuracyBar;

    public Text damageTxt;
    public Text rateFireTxt;
    public Text accuracyTxt;

    public Button upGradeBtn;
    public int IdWeapon;
    private void Awake()
    {
        quiteBtn.onClick.AddListener(CloseTab);
        upGradeBtn.onClick.AddListener(upGradeWeapon);
    }
    public void Init(int IdGun)
    {
        InforWeaponManager._instance.SetDeActiveCurrentWeapon();
        gameObject.SetActive(true);
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(new Vector3(1, 1, 1), 0.5f);

    }    
    public void loadInforWeaponLevelUp()
    {

    }
    public void upGradeWeapon()
    {
        if(DataPlayer.GetInforPlayer().countDiamond>200)
        {
            // show notice 
            // load gun again 
            // gameObject SetActive false
        }
    }
    public void CloseTab()
    {
        InforWeaponManager._instance.SetActiveCurrentWeapon();
        transform.DOScale(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>gameObject.SetActive(false));
    }
}
