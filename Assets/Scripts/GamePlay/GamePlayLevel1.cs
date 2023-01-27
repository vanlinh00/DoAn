using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLevel1 : GamePlay
{
    public List<EnemyController> ListEnemys;
    public int countEnemy;
    private void Start()
    {
        countEnemy = ListEnemys.Count;
    }
    public override void CheckEnemysColistionWihtBoom(Transform BomTrans)
    {
        base.CheckEnemysColistionWihtBoom(BomTrans);
        for (int i = 0; i < ListEnemys.Count; i++)
        {
            float DisEnemyBoom = Vector3.Distance(ListEnemys[i].transform.position, BomTrans.position);
            if (DisEnemyBoom < 5)
            {
                ListEnemys[i].Damage(500f);
            }
        }
    }
    public override void EndGame()
    {
        base.EndGame();
        CalculaterStar();

    }
    public override void WinGame()
    {
        base.WinGame();
        CalculaterStar();

    }
    public void CalculaterStar()
    {
        float DeathRate = (countEnemy - MainUi._instance.CurrentAmountEnemy) / (float)countEnemy;
        int AmountStar = 0;
        if (DeathRate >= 1)
        {
            AmountStar = 3;
        }
        else if (DeathRate < 1 && DeathRate >= 0.5)
        {
            AmountStar = 2;
        }
        else if (DeathRate < 0.5 && DeathRate >= 0.1)
        {
            AmountStar = 1;
        }
        else
        {
            AmountStar = 0;
        }

        if (DataPlayer.GetInforPlayer().listCountStarLevel[IdLevel - 1] < AmountStar)
        {
            DataPlayer.UpdateCountStar(IdLevel - 1, AmountStar);
        }
    }
}
