using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    [SerializeField] GameObject _gun1;
    [SerializeField] GameObject _gun2;
    [SerializeField] GameObject _frag;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        _gun1.SetActive(true);
        _frag.SetActive(false);
        _gun2.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            UiScope._instance.SetNormalScope();
            StartCoroutine(UseGun1());
        }
        if (Input.GetKeyDown("2"))
        {
            UiScope._instance.SetNormalScope();
            StartCoroutine(UseGun2());
        }

        if (Input.GetKeyDown("3"))
        {
            UiScope._instance.SetNormalScope();
            StartCoroutine(UseFrag());
        }
        if(Input.GetKeyDown("4")&&_gun2.activeSelf)
        {
            UiScope._instance.SetScopeAWM();
            _gun2.transform.localPosition = new Vector3(0, 0, -10f);


        }
    }
    IEnumerator UseFrag()
    {
        if (_gun1.activeSelf)
        {
            _gun1.transform.GetChild(0).GetComponent<Weapon>().StateReady();
            yield return new WaitForSeconds(0.1f);
            _gun1.SetActive(false);
        }

       if(_gun2.activeSelf)
        {
            if (_gun2.transform.childCount >= 1)
            {
                _gun2.transform.GetChild(0).GetComponent<Weapon>().StateReady();
            }
            yield return new WaitForSeconds(0.1f);
            _gun2.SetActive(false);

        }
        _frag.SetActive(true);
        _frag.GetComponent<Weapon>().StateReady();
    }

    IEnumerator UseGun1()
    {
        if (_gun2.activeSelf)
        {
            if (_gun2.transform.childCount >= 1)
            {
                _gun2.transform.GetChild(0).GetComponent<Weapon>().StateReady();
            }
            yield return new WaitForSeconds(0.1f);
            _gun2.SetActive(false);
        }

        if(_frag.activeSelf)
        {
            _frag.GetComponent<Weapon>().StateReady();
            yield return new WaitForSeconds(0.1f);
            _frag.SetActive(false);

        }
        _gun1.SetActive(true);
        _gun1.transform.GetChild(0).GetComponent<Weapon>().StateReady();

    }

    IEnumerator UseGun2()
    {
        if (_gun1.activeSelf)
        {
            _gun1.transform.GetChild(0).GetComponent<Weapon>().StateReady();
            yield return new WaitForSeconds(0.1f);
            _gun1.SetActive(false);
        }

        if (_frag.activeSelf)
        {
            _frag.GetComponent<Weapon>().StateReady();
            yield return new WaitForSeconds(0.1f);
            _frag.SetActive(false);

        }
        _gun2.SetActive(true);
        _gun2.transform.localPosition = new Vector3(0, 0, 0);
        if (_gun2.transform.childCount>=1)
        {
            _gun2.transform.GetChild(0).GetComponent<Weapon>().StateReady();
        }
    
    }

  public  void ChangeGun(int idNewGun)
    {
        if(!_frag.activeSelf&&DataPlayer.GetInforPlayer().idGun2!=idNewGun&& DataPlayer.GetInforPlayer().idGun1 != idNewGun)
        {
          //  GameObject Gun = ObjectPooler._instance.SpawnFromPool("Gun"+idNewGun, _gun1.transform.position, Quaternion.identity);

            if (_gun2.activeSelf)
            {
                //if (_gun2.transform.childCount >= 1)
                //{
                //    GameObject OldGun2 = _gun2.transform.GetChild(0).gameObject;
                //    ObjectPooler._instance.AddElement("Gun" + OldGun2.GetComponent<Gun>().idGun, OldGun2);
                //    OldGun2.transform.parent = ObjectPooler._instance.transform;
                //    OldGun2.SetActive(false);
                //}
                //Gun.transform.parent = _gun2.transform;
                for (int i = 0; i < _gun2.transform.childCount; i++)
                {
                    _gun2.transform.GetChild(i).gameObject.SetActive(false);
                }
                _gun2.transform.GetChild(idNewGun - 1).gameObject.SetActive(true);
                DataPlayer.UpdateGun2(idNewGun);
            }
            if (_gun1.activeSelf)
            {
                for(int i=0;i< _gun1.transform.childCount;i++)
                {
                    _gun1.transform.GetChild(i).gameObject.SetActive(false);
                }
                _gun1.transform.GetChild(idNewGun - 1).gameObject.SetActive(true);
                DataPlayer.UpdateGun1(idNewGun);
                //if (_gun1.transform.childCount >= 1)
                //{
                //    GameObject OldGun1 = _gun1.transform.GetChild(0).gameObject;
                //    ObjectPooler._instance.AddElement("Gun" + OldGun1.GetComponent<Gun>().idGun, OldGun1);
                //    OldGun1.transform.parent = ObjectPooler._instance.transform;
                //    OldGun1.SetActive(false);
                //}
                //Gun.transform.parent = _gun1.transform;
                //Gun.transform.localPosition = new Vector3(0, 0, 0);
            }
            //Gun.transform.localPosition = new Vector3(0, 0, 0);
            //Gun.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //Gun.transform.localScale = new Vector3(1, 1, 1);

        }  
    }

    //void ChangeGun()
    //{
    //    StartCoroutine(WaitTimeChangeGun());
    //}
    //IEnumerator WaitTimeChangeGun()
    //{
    //    if (_augGun.activeSelf)
    //    {
    //        _augGun.GetComponent<Weapon>().StateReady();
    //        yield return new WaitForSeconds(0.1f);
    //        _augGun.SetActive(false);
    //        _akGun.SetActive(true);
    //         _akGun.GetComponent<Weapon>().StateReady();
    //    }
    //    else
    //    {
    //        _akGun.GetComponent<Weapon>().StateReady();
    //        yield return new WaitForSeconds(0.1f);
    //        _akGun.SetActive(false);
    //        _augGun.SetActive(true);
    //        _augGun.GetComponent<Weapon>().StateReady();
    //    }
    //}
}
