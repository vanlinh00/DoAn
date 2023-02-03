using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public List<EnemyController> ListEnemys;
    public int IdLevel;
    public InforLevelData inforLevelData;
    public virtual int GetCountEnemies()
    {
        return ListEnemys.Count;
    }
    public virtual void CheckEnemysColistionWihtBoom(Transform BomTrans)
    {
        for (int i = 0; i < ListEnemys.Count; i++)
        {
            float DisEnemyBoom = Vector3.Distance(ListEnemys[i].transform.position, BomTrans.position);
            if (DisEnemyBoom < 5)
            {
                ListEnemys[i].Damage(500f);
            }
        }
    }
    public virtual void EndGame()
    {
        UiController._instance.ActiveEndGameUi();
        Debug.Log("EndGame");
    }
    public virtual void WinGame()
    {
        UiController._instance.ActiveEndGameUi();
        Debug.Log("WinGame");
    }
    public virtual void SetCantFindObj()
    {

    }
    public virtual void CalculaterStar()
    {
        float DeathRate = (ListEnemys.Count - MainUi._instance.CurrentAmountEnemy) / (float)ListEnemys.Count;
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
        if (UserDataPref.GetAmountStarLevel(IdLevel) < AmountStar)
        {
            UserDataPref.SetAmountStarLevel(IdLevel, AmountStar);
        }
        UpdateDiamondAndKey(AmountStar);
    }
    public void UpdateDiamondAndKey(int NumberStar)
    {
        if (NumberStar <= 0)
            return;

        int NumberKeys = DataPlayer.GetInforPlayer().countKeys + inforLevelData.reward[NumberStar - 1].numberKey;
        if (NumberKeys > 3)
            NumberKeys = 3;

        DataPlayer.UpdateAmountKeys(NumberKeys);

        int NumberDiamond = DataPlayer.GetInforPlayer().countDiamond + inforLevelData.reward[NumberStar - 1].numberDimond;
        DataPlayer.UpdateAmountDiamond(NumberDiamond);
    }
}
