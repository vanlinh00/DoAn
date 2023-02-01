using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy2 : EnemyController
{
    // no di tuan tra trong khu vuc cua no
    // no phat hieen ra player
    // bao no quay ve can cu bao cho ca con enemy khac cac con enemy khac den ban player

    public Transform PosTeam1;
    private bool IsNotice;
    public bool IsColliderTeam1;
    protected override void Awake()
    {
        base.Awake();
        IsColliderTeam1 = false;
        IsNotice = false;
    }
    protected override void Update()
    {
        //base.Update();
        if (!isDead)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            if (playerInSightRange && !IsNotice)
            {
                IsNotice = true;
                NotifyTeammates();

            }
            else if (IsNotice)
            {
                if (IsColliderTeam1)
                {
                    playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
                    if (playerInAttackRange)
                    {
                        AttackPlayer();
                    }
                    else
                    {
                        ChasePlayer();
                    }
                }
            }
        }
    }
    public void NotifyTeammates()
    {
        Destroy(gameObject.GetComponent<DOTweenPath>());
        agent.destination = PosTeam1.position;
        agent.speed = 7f;
    }
}
