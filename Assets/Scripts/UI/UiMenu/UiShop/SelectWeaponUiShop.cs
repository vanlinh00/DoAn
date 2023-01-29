using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SelectWeaponUiShop : Singleton<SelectWeaponUiShop>
{
    [SerializeField] GameObject _content;
    public int idWeaPonDisplay = 1;
    public UpgrapdeWeapon upgrapdeWeapon;
    public Button upGrapdeBtn;
    public List<GunData> gunDatas;
    protected override void Awake()
    {
        base.Awake();
        upGrapdeBtn.onClick.AddListener(UpGrapde);
    }
    private void OnEnable()
    {
        OpenStoreWeapon(1);
    }
    public void UpGrapde()
    {
        upgrapdeWeapon.Init(idWeaPonDisplay);
    }

    // chosse = 1 create list guns
    // chosse = 2 create list knives
    // chosse = 3 create list pans
    public void OpenStoreWeapon(int idTypeWeaPon)
    {
        idWeaPonDisplay = idTypeWeaPon;

        foreach (Transform child in _content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 1; i < 10; i++)
        {
            CreateListGuns(i, idTypeWeaPon);
        }
        DOVirtual.DelayedCall(0.1f, _content.transform.GetChild(0).GetComponent<ShopButtonElement>().SelectWeapon);
    }

    void CreateListGuns(int i, int TypeWeapon)
    {
        GameObject newButtonWeapon = Instantiate(Resources.Load("UI/UiShop/shop_button_element", typeof(GameObject)), _content.transform.position, Quaternion.identity) as GameObject;
        newButtonWeapon.transform.SetParent(_content.transform);
        switch (TypeWeapon)
        {
            case 1:

                if (i >= gunDatas.Count)
                {
                    newButtonWeapon.GetComponent<ShopButtonElement>().IsButtonGun(i, "NewGun");
                }
                else
                {
                  
                    newButtonWeapon.GetComponent<ShopButtonElement>().IsButtonGun(i, gunDatas[i].name);
                    int idLevelGun = UserDataPref.GetLevelGun(gunDatas[i].id) - 1;
                    ShopButtonElement shopButtonE = newButtonWeapon.GetComponent<ShopButtonElement>();
                    shopButtonE._weapon.idWeapon = gunDatas[i].id;
                    shopButtonE._weapon.damage = gunDatas[i].listDamage[idLevelGun];
                    shopButtonE._weapon.rateOfFire = gunDatas[i].listRateOfFire[idLevelGun];
                    shopButtonE._weapon.accuracy = gunDatas[i].listAccuracy[idLevelGun];
                    shopButtonE._weapon.priceForCoin = gunDatas[i].priceForCoint;
                    shopButtonE._weapon.priceForDiamond = gunDatas[i].pirceForDiamond;
                    shopButtonE._weapon.name = gunDatas[i].name;
                    shopButtonE._weapon.level = idLevelGun + 1;
                }

                break;
            case 2:
                break;
            case 3:

                break;
        };

        if (!DataPlayer.GetInforPlayer().listIdGun.Contains(i))
        {
            newButtonWeapon.GetComponent<ShopButtonElement>().IsLock();
        }
    }
}