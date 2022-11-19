using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonElement : MonoBehaviour
{
    public int id;
    public Image _backGround;
    public WeaPonShop _weapon;
    public Image _weaponImage;
    public Text _textnameWeapon;
    public Button _btSelectWeapon;
    public GameObject _darkBackGround;
    public GameObject _lock;
    private void Awake()
    {
        _btSelectWeapon.onClick.AddListener(SelectWeapon);
    }
    public void IsLock()
    {
        _darkBackGround.SetActive(true);
        _lock.SetActive(true);
    }
    public void IsButtonGun(int idImage)
    {
        _weaponImage.sprite = Resources.Load<Sprite>("Image/Shop/Guns/" + idImage);
    }
    public void SelectWeapon()
    {

        // _backGround.color = new Color32(255, 25, 43, 225);
        InforWeaponManager._instance.ChangePropertiesGun(_weapon.damage, _weapon.rateOfFire, _weapon.accuracy, _weapon.name, _weapon.idWeapon, _weapon.priceForCoin, _weapon.priceForDiamond);
    }

}
