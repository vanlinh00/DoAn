using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLevel3 : GamePlay
{
    public Transform chestObj;
    public MapDirection mapDirection;
    public bool IsCantFindObj;
    private void Awake()
    {
        IsCantFindObj = true;
    }
    public void Update()
    {
         if(Input.GetKeyDown("f")&& IsCantFindObj)
        {
            IsCantFindObj = false;
            mapDirection.target = chestObj.position;
            mapDirection.FindDirection(false);
        }
    }
    public override void SetCantFindObj()
    {
        IsCantFindObj = true;
    }    

}
