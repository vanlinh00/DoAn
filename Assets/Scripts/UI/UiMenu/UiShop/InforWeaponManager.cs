using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class InforWeaponManager : Singleton<InforWeaponManager>
{
    [SerializeField] Image _barDamageWeapon;
    [SerializeField] Image _barRateOfFireWeapon;
    [SerializeField] Image _barAccuracyWeapon;
    [SerializeField] Text _nameWeapon;

    [SerializeField] Text _priceWeaponFCoinTxt;
    [SerializeField] Text _priceWeaponFDiamondTxt;

    public GameObject _weaPonCurrent;

   [SerializeField] Vector3 _positionGun;

    protected override void Awake()
    {
        base.Awake();
    }
    public void SetActiveCurrentWeapon()
    {
        _weaPonCurrent.gameObject.SetActive(true);
        _weaPonCurrent.transform.localScale = Vector3.zero;
        _weaPonCurrent.transform.DOScale(new Vector3(0.6f,0.6f,0.6f), 0.5f);
    }
    public void SetDeActiveCurrentWeapon()
    {
        _weaPonCurrent.transform.DOScale(Vector3.zero, 0.5f).OnComplete(()=> _weaPonCurrent.gameObject.SetActive(false));
    }
    public void ChangePropertiesGun(float newDamage, float newRateOfFire, float newAccuracy, string nameGun, int idWeapon, int priceForCoin, int priceForDiamond)
    {
        _barDamageWeapon.fillAmount = newDamage;
        _barRateOfFireWeapon.fillAmount = newRateOfFire;
        _barAccuracyWeapon.fillAmount = newAccuracy;
        _nameWeapon.text = nameGun;

        _priceWeaponFCoinTxt.text = "Buy it for " + priceForCoin.ToString();
        _priceWeaponFDiamondTxt.text = "Buy it for " + priceForDiamond.ToString();

        CreateWeapon(idWeapon);
    }
    public void CreateWeapon(int idWeapon)
    {
        if (_weaPonCurrent != null)
        {
            Destroy(_weaPonCurrent);
        }

        if (SelectWeaponUiShop._instance.idWeaPonDisplay == 1)
        {
            string nameGunInAsset = "Gun_" + idWeapon;
            GameObject _newWeapon = Instantiate(Resources.Load("UI/UiShop/TypeWeapon1/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
            _weaPonCurrent = _newWeapon;
        }

        //if (SelectWeaponUiShop._instance.getIdWeaPonDisplay() == 2)
        //{
        //    string nameGunInAsset = "Knife_" + idWeapon;
        //    GameObject _newWeapon = Instantiate(Resources.Load("ShopeGun/Weapon/Knives/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
        //    _weaPonCurrent = _newWeapon;
        //}

    }
}
