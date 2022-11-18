using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject _augGun;
    [SerializeField] GameObject _akGun;
    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            ChangeGun();
        }

    }
    void ChangeGun()
    {
        StartCoroutine(WaitTimeChangeGun());
    }
    IEnumerator WaitTimeChangeGun()
    {
        if (_augGun.activeSelf)
        {
            _augGun.GetComponent<Weapon>().StateReady();
            yield return new WaitForSeconds(0.1f);
            _augGun.SetActive(false);
            _akGun.SetActive(true);
             _akGun.GetComponent<Weapon>().StateReady();
        }
        else
        {
            _akGun.GetComponent<Weapon>().StateReady();
            yield return new WaitForSeconds(0.1f);
            _akGun.SetActive(false);
            _augGun.SetActive(true);
            _augGun.GetComponent<Weapon>().StateReady();

        }
    }
}
