using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragController : Weapon
{
    public bool timeBetween;
    private void Start()
    {
    
        timeReload = 5f;
    }
    private void OnEnable()
    {    timeBetween = true; 
    }
    public void Update()
    {
        if (GameState.stateGame != StateGame.OpenStore&& timeBetween)
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = _camera.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                _shootPoint = raycastHit.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (_countBullet != 0)
                {
                    Shoot();
                }
                else
                {
                    StartCoroutine(IEReload());
                }
            }
            if (Input.GetKeyDown("q"))
            {
                StartCoroutine(IEReload());
            }

        }
    }

    public void Shoot()
    {
        StartCoroutine(WaitTimeBullet());
    }
    IEnumerator WaitTimeBullet()
    {
        timeBetween = false;
        _animator.SetTrigger("Fire");
        yield return new WaitForSeconds(1f);
        GameObject Bomb = ObjectPooler._instance.SpawnFromPool("Bomb2", _gunHead.position, _gunHead.rotation);
        Bomb.GetComponent<Frag>()._firePoint = _shootPoint;
        Bomb.GetComponent<Frag>().Fly();
        _countBullet--;
        MainUi._instance.LoadGunPlaying(transform.GetComponent<Weapon>(), true);
        yield return new WaitForSeconds(1f);
        timeBetween = true;
    }
}
