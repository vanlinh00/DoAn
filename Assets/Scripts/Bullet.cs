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
        ObjectPooler._instance.AddElement("Bullet", transform.gameObject);
        transform.gameObject.SetActive(false);

        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            // cach 2 dung interface
            //IDamageable Damage = collision.gameObject.GetComponent<IDamageable>();
            //if (Damage != null)
            //{
            //    Damage.Damage();
            //}
        }

    }

}