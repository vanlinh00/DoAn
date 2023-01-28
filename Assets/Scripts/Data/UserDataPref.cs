using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UserDataPref 
{
    public static int GetAmountStarLevel(int IdLevel)
    {
        return PlayerPrefs.GetInt("level_count_star" + IdLevel);
    }
    public static void SetAmountStarLevel(int IdLevel, int CountStar)
    {
        PlayerPrefs.SetInt("level_count_star" + IdLevel, CountStar);
    }
}
