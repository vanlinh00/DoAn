using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, ImoveBulletable
{
    public Vector3 _firePoint { get; set; }
    private float speed = 2f;
    public void Fly()
    {
        //  SoundManager.instance.OnPlayAudio(SoundType.AKFire);
        transform.position = Vector3.Lerp(transform.position, _firePoint, speed * Time.timeScale);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            IDamageable Damage = collision.gameObject.GetComponent<IDamageable>();
            if (Damage != null)
            {
                Damage.Damage();
            }
            ObjectPooler._instance.AddElement("Bullet", transform.gameObject);
            transform.gameObject.SetActive(false);
        }

    }

}