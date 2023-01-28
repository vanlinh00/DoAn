using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public int IdLevel;
    public virtual void CheckEnemysColistionWihtBoom(Transform BomTrans)
    {

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
    public virtual int GetCountEnemies()
    {
        return 0;
    }
}
