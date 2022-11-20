using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator _animator;
    public Transform _gunHead;
    public Vector3 _shootPoint;
    public Camera _camera;
  
    public void StateReady()
    {
        _animator.SetTrigger("Ready");
    }
}
