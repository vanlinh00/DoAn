using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour,IDamageable
{
    Transform player;
    NavMeshAgent nav;
    public float minDistancePlayer;
    [SerializeField] Animator _animator;
    public bool isHit = false;
    public float health = 1000f;
    [SerializeField] Image _valueHealthImg;
    public enum StateEnemy
    {
        run,
        shoot,
        idle,
    }
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        StateRun();
    }

    void Update()
    {
        nav.SetDestination(player.position);
        if (Vector3.Distance(player.position, transform.position) <= minDistancePlayer/*&& !isHit*/)
        {
          //  StateHit();
         //   isHit = true;
            nav.speed = 1f;
          //  StateRun();
        }
        else
        {
            nav.speed = 5f;
        }
        //else
        //{
        //    StateIdle();
        //}
    }
    public void StateIdle()
    {
        _animator.SetBool("Run", false);
    }
    public void StateRun()
    {
        _animator.SetBool("Run", true);
    }
    public void StateHit()
    {
        _animator.SetTrigger("Hit");
    }
    public void Damage()
    {
        health=health - 200f;
        _valueHealthImg.fillAmount = health / 1000f;
        if (health==0)
        {
            Die();
        }
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
}
