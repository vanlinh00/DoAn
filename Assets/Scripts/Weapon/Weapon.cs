using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator _animator;
    public Transform _gunHead;
    public Vector3 _shootPoint;
    public Camera _camera;
    public string _name;
    public int _countBullet;
    public int _amountbullets;
    public int idGun;
    public int _countTotalBullets;

    public bool isReloading;
    public float timeReload;
    private void Start()
    {
        isReloading = true;
    }
    private void Awake()
    {
        _amountbullets = _countBullet;
    }
    public void StateReady()
    {
        _animator.SetTrigger("Ready");
    }
    public IEnumerator IEReload()
    {
        isReloading = false;
        _animator.SetTrigger("Reload");
        _countBullet = _amountbullets;
        yield return new WaitForSeconds(timeReload);
        isReloading = true;
    }
}
