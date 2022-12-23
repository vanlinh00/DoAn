using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragController : Weapon
{
    public void Update()
    {
        if (GameState.stateGame != StateGame.OpenStore)
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = _camera.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                _shootPoint = raycastHit.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                 if(_countBullet!=0)
                {
                    Shoot();
                }
                else
                {
                    _animator.SetTrigger("Reload");
                    _countBullet = _amountbullets;
                }
    
            }
            if (Input.GetKeyDown("q"))
            {
                _animator.SetTrigger("Reload");
            }

        }
    }
    public void OnEnable()
    {
        _camera = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<Camera>();
    }
    public void Shoot()
       {
        StartCoroutine(WaitTimeBullet());
        }
    IEnumerator WaitTimeBullet()
    {
        _animator.SetTrigger("Fire");
        yield return new WaitForSeconds(1f);
        GameObject Bomb = ObjectPooler._instance.SpawnFromPool("Bomb2", _gunHead.position, _gunHead.rotation);
        Bomb.GetComponent<Frag>()._firePoint = _shootPoint;
        Bomb.GetComponent<Frag>().Fly();
        _countBullet--;
        // Bomb.GetComponent<Rigidbody>().AddForce(transform.forward*2000f);
    }
}
