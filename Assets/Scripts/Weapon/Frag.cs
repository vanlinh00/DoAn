using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frag : MonoBehaviour, ImoveBulletable
{
    public Vector3 _firePoint { get; set; }
    private float speed = 1f;
    [SerializeField] GameObject _explosion;
    public void Fly()
    {
        transform.position = Vector3.Lerp(transform.position, _firePoint, speed * Time.timeScale);
    }
    private void OnCollisionEnter(Collision collision)
    {
        _explosion.SetActive(true);
    }

 }
