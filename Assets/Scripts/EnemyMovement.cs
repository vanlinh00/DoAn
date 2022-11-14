using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    public float minDistancePlayer;
    [SerializeField] Animator _animator;
    public bool isHit = false;
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
}
