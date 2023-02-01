using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollumNotify : MonoBehaviour
{
    public List<Enemy3> enemiesTeam1;
    public List<Enemy4> enemiesTeam2;
    private bool isNotice;
    private void Start()
    {
        isNotice = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")&& !isNotice)
        {
            isNotice = true;
            other.gameObject.GetComponent<Enemy2>().IsColliderTeam1 = true;
            for (int i=0;i<enemiesTeam1.Count;i++)
            {
                enemiesTeam2[i].SetStateEnemy(false);
                enemiesTeam1[i].isAttackPlayer = true;
             }
        }
    }
}
