using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaPonShop:MonoBehaviour
{
    public int idType;
    public int idWeapon;
    public string name { get; set; }
    public float damage { get; set; }
    public float rateOfFire { get; set; }
    public float accuracy { get; set; }
    public int priceForCoin { get; set; }
    public int priceForDiamond { get; set; }
}
