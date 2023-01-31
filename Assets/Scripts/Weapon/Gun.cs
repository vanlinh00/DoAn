using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public int power;
    public ParticleSystem _explosionVfx;

    public void Update()
    {
        if (GameState.stateGame != StateGame.OpenStore&& isReloading)
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = MainCamera._instance.gameObject.GetComponent<Camera>().ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                _shootPoint = raycastHit.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (_countBullet != 0)
                {
                    _explosionVfx.Play();
                    SoundController._instance.OnPlayAudio(SoundType.Akfire);
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
        GameObject Bullet = ObjectPooler._instance.SpawnFromPool("Bullet", _gunHead.position, _gunHead.rotation);
        Bullet bullet = Bullet.GetComponent<Bullet>();
        bullet.power = power;
        bullet._firePoint = _shootPoint;
        bullet.Fly();
        _animator.SetTrigger("Fire");

        /*transform.GetComponent<Weapon>().*/
        _countBullet--;

        MainUi._instance.LoadGunPlaying(transform.GetComponent<Weapon>());
        yield return new WaitForSeconds(0.1f);
        ObjectPooler._instance.AddElement("Bullet", Bullet);
        Bullet.SetActive(false);

    }

}
