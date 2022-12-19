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
    public int idGun;
    public int _countTotalBullets;
    //public int 

    public void StateReady()
    {
        _animator.SetTrigger("Ready");
    }
}
