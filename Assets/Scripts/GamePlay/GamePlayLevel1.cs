using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLevel1 : GamePlay
{
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

}
