using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public int idGun;

    public  void  Update()
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
                Shoot();
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
        GameObject Bullet = ObjectPooler._instance.SpawnFromPool("Bullet", _gunHead.position, _gunHead.rotation);
        Bullet.GetComponent<Bullet>()._firePoint = _shootPoint;
        Bullet.GetComponent<Bullet>().Fly();
        _animator.SetTrigger("Fire");
        yield return new WaitForSeconds(0.1f);
        ObjectPooler._instance.AddElement("Bullet", Bullet);
        Bullet.SetActive(false);
    }

}
