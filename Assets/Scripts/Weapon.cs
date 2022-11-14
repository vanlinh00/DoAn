using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Animator _animator;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKey("q"))
        {
            _animator.SetTrigger("Reload");
        }
    }
    public void Shoot()
    {
        _animator.SetTrigger("Fire");
    }
}
