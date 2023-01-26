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
        Debug.Log("EndGame");
    }
    public virtual void WinGame()
    {
        Debug.Log("WinGame");
    }
}
