using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeaponUiShop : Singleton<SelectWeaponUiShop>
{
    [SerializeField] GameObject _content;
    private int idWeaPonDisplay = 1;
    private int allWeapon = 10;
 //   private int allWeaponUnlock = 2;
    DataListWeapon dataListWeapon = new DataListWeapon();
    protected override void Awake()
    {
        base.Awake();
     
    }
    private void OnEnable()
    {
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
        SetData(idWeaPonDisplay, allWeapon);

        yield return new WaitForSeconds(0.1f);
        _content.transform.GetChild(0).GetComponent<ShopButtonElement>().SelectWeapon();
    }

    // chosse = 1 create list guns
    // chosse = 2 create list knives
    // chosse = 3 create list pans
    public void SetData(int choose, int allWeapon)
    {
        TextAsset jsonFile= Resources.Load("DataPlayer/DataGun") as TextAsset;

        dataListWeapon = JsonUtility.FromJson<DataListWeapon>(jsonFile.text);

        //Debug.Log(dataListWeapon.ListDataGun.Length);
        //Debug.Log(.idWeapon);

        foreach (Transform child in _content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 1; i < allWeapon; i++)
        {
            CreateListGuns(i, choose, dataListWeapon.ListDataGun[i-1]);
        }
    }
    void CreateListGuns(int i,  int choose, WeaPonShop listWeaponShop  )
    {
        GameObject newButtonWeapon = Instantiate(Resources.Load("UI/UiShop/shop_button_element", typeof(GameObject)), _content.transform.position, Quaternion.identity) as GameObject;
        newButtonWeapon.transform.SetParent(_content.transform);

        //float randomDamge = Random.RandomRange(0.2f, 1f);
        //float randomrateOfFire = Random.RandomRange(0.2f, 1f);
        //float randomaccuracy = Random.RandomRange(0.2f, 1f);
        //int randomPriceForCoin = Random.RandomRange(200, 300);
        //int randomPriceForDiamond = Random.RandomRange(100, 150);

        ShopButtonElement shopButtonE = newButtonWeapon.GetComponent<ShopButtonElement>();
        shopButtonE._weapon.idWeapon = listWeaponShop.idWeapon;
        shopButtonE._weapon.damage = listWeaponShop.damage;
        shopButtonE._weapon.rateOfFire = listWeaponShop.rateOfFire;
        shopButtonE._weapon.accuracy = listWeaponShop.accuracy;
        shopButtonE._weapon.priceForCoin = listWeaponShop.priceForCoin;
        shopButtonE._weapon.priceForDiamond = listWeaponShop.priceForDiamond;
        shopButtonE._weapon.name = listWeaponShop.name;
        switch (choose)
        {
            case 1:
                newButtonWeapon.GetComponent<ShopButtonElement>().IsButtonGun(i);
                newButtonWeapon.GetComponent<ShopButtonElement>()._textnameWeapon.text = listWeaponShop.name;
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