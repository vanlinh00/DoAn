using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : EnemyController
{
    //protected override void Patroling()
    //{
    //    //base.Patroling();
    //    Debug.Log("Patroling");
    //}
    //protected override void ChasePlayer()
    //{
    //    Debug.Log("ChasePlayer");
    //    //base.ChasePlayer();
    //}

    //protected override void AttackPlayer()
    //{
    //    Debug.Log("AttackPlayer");
    //    //base.AttackPlayer();
    //}
    public override void StateRun()
    {
        Debug.Log("Run");
    }
    public override void StateHit()
    {
        Debug.Log("Hit");

    }

}
