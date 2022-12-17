using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : Singleton<GamePlay>
{
    public List<EnemyController> ListEnemys;
    public void CheckEnemysColistionWihtBoom(Transform BomTrans)
    {
        for(int i=0;i< ListEnemys.Count;i++)
        {
            float DisEnemyBoom = Vector3.Distance(ListEnemys[i].transform.position, BomTrans.position);
            if(DisEnemyBoom<5)
            {
                ListEnemys[i].Damage(500f);
            }
        }
    }
}
