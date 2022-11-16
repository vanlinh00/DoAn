using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Transform _gunHead;
    Vector3 _shootPoint;
    [SerializeField] Camera _camera;

    void Update()
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
        if (Input.GetKey("q"))
        {
            _animator.SetTrigger("Reload");
        }
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
