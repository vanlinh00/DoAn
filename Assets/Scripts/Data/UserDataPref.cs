using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UserDataPref 
{
    public static int GetAmountStarLevel(int IdLevel)
    {
        return PlayerPrefs.GetInt("level_count_star" + IdLevel,0);
    }
    public static void SetAmountStarLevel(int IdLevel, int CountStar)
    {
        PlayerPrefs.SetInt("level_count_star" + IdLevel, CountStar);
    }

    public static int GetLevelGun(int IdGun)
    {
        return PlayerPrefs.GetInt("gun_level" + IdGun,1);
    }
    public static void SetLevelGun(int IdGun,int Level)
    {
        PlayerPrefs.SetInt("gun_level" + IdGun, Level);
    }
}
