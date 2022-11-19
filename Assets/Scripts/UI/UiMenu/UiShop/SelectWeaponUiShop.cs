using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeaponUiShop : Singleton<SelectWeaponUiShop>
{
    [SerializeField] GameObject _content;

    private int idWeaPonDisplay = 1;
    private int allWeapon = 10;
    private int allWeaponUnlock = 2;

    protected override void Awake()
    {
        base.Awake();
        OpenStoreWeapon(1);
    }
    public int getIdWeaPonDisplay()
    {
        return idWeaPonDisplay;
    }
    public void OpenStoreWeapon(int idChooseWeaPon)
    {

        StartCoroutine(OpenStoreWeaponCoroutine(idChooseWeaPon));
    }

    IEnumerator OpenStoreWeaponCoroutine(int idChooseWeaPon)
    {
        idWeaPonDisplay = idChooseWeaPon;
        SetData(idWeaPonDisplay, allWeapon, allWeaponUnlock);
        InforWeaponManager._instance.CreateWeapon(1);

        yield return new WaitForSeconds(0.1f);

        _content.transform.GetChild(0).GetComponent<ShopButtonElement>().SelectWeapon();
    }

    // chosse = 1 create list guns
    // chosse = 2 create list knives
    // chosse = 3 create list pans
    public void SetData(int choose, int allWeapon, int allWeaponUnlock)
    {
        foreach (Transform child in _content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 1; i < allWeapon; i++)
        {
            CreateListGuns(i, allWeaponUnlock, choose);
        }
    }
    void CreateListGuns(int i, int allWeaponUnlock, int choose)
    {
        GameObject newButtonWeapon = Instantiate(Resources.Load("UI/UiShop/shop_button_element", typeof(GameObject)), _content.transform.position, Quaternion.identity) as GameObject;
        newButtonWeapon.transform.SetParent(_content.transform);

        float randomDamge = Random.RandomRange(0.2f, 1f);
        float randomrateOfFire = Random.RandomRange(0.2f, 1f);
        float randomaccuracy = Random.RandomRange(0.2f, 1f);
        int randomPriceForCoin = Random.RandomRange(200, 300);
        int randomPriceForDiamond = Random.RandomRange(100, 150);

        ShopButtonElement shopButtonE = newButtonWeapon.GetComponent<ShopButtonElement>();
    //    shopButtonE._weapon.id = i;
        shopButtonE._weapon.damage = randomDamge;
        shopButtonE._weapon.rateOfFire = randomrateOfFire;
        shopButtonE._weapon.accuracy = randomaccuracy;
        shopButtonE._weapon.priceForCoin = randomPriceForCoin;
        shopButtonE._weapon.priceForDiamond = randomPriceForDiamond;



        switch (choose)
        {
            case 1:
                newButtonWeapon.GetComponent<ShopButtonElement>()._weapon.name = "gun" + i;
                newButtonWeapon.GetComponent<ShopButtonElement>().IsButtonGun(i);
                newButtonWeapon.GetComponent<ShopButtonElement>()._textnameWeapon.text = "Gun" + i;
                break;
            case 2:
                newButtonWeapon.GetComponent<ShopButtonElement>()._weapon.name = "knive" + i;
              //  newButtonWeapon.GetComponent<ShopButtonElement>().IsButtonKnive(i);
                newButtonWeapon.GetComponent<ShopButtonElement>()._textnameWeapon.text = "Knife" + i;
                break;
            case 3:
                newButtonWeapon.GetComponent<ShopButtonElement>()._weapon.name = "pan" + i;
              //  newButtonWeapon.GetComponent<ShopButtonElement>().IsButtonKPan();
                break;
        };

        if (i > allWeaponUnlock)
        {
            newButtonWeapon.GetComponent<ShopButtonElement>().IsLock();
        }
    }


}