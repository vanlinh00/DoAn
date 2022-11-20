using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] GameObject _storeUnlocked;
    [SerializeField] GameObject _storeNotUnlocked;

    private void OnEnable()
    {
        foreach (Transform child in _storeUnlocked.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        LoadDataStoreUnlocked();
    }
    public  void LoadDataStoreUnlocked()
    {
        for (int i=0;i< DataPlayer.GetInforPlayer().listIdGun.Count;i++)
        {
            GameObject newButtonWeapon = Instantiate(Resources.Load("UI/UiStore/ItemUnlockedPrefab", typeof(GameObject)), _storeUnlocked.transform.position, Quaternion.identity) as GameObject;
            newButtonWeapon.transform.SetParent(_storeUnlocked.transform);
            newButtonWeapon.GetComponent<ItemBtn>()._idGun = DataPlayer.GetInforPlayer().listIdGun[i];
            newButtonWeapon.GetComponent<ItemBtn>().LoadImage();
        }

    }
}
