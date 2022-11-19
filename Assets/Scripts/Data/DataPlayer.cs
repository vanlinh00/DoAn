using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static InforPlayer inforPlayer;
    static DataPlayer()
    {
        inforPlayer = JsonUtility.FromJson<InforPlayer>(PlayerPrefs.GetString(ALL_DATA));
        if (inforPlayer == null)
        {
            inforPlayer = new InforPlayer
            {
                isOnMusicBg = true,
                countCoins = 0,
                isOnSound = true,
                listIdGun = new List<int>() { 1 },
                level = 1,
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(inforPlayer);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static void UpdateAmountCoins(int Amount)
    {
        inforPlayer.countCoins = Amount;
        SaveData();
    }
    public static void ChangeStateAudio(bool IsOnAudio)
    {
        inforPlayer.isOnMusicBg = IsOnAudio;
        SaveData();
    }
    public static void ChangeStateSound(bool IsOnAudio)
    {
        inforPlayer.isOnSound = IsOnAudio;
        SaveData();
    }
    public static void UpdateLevel(int Level)
    {
        inforPlayer.level = Level;
        SaveData();
    }
    public static void AddNewlistIdBranchs(int idGun)
    {
        inforPlayer.listIdGun.Add(idGun);
        SaveData();

    }
    public static InforPlayer GetInforPlayer()
    {
        return inforPlayer;
    }
}
public class InforPlayer
{
    public bool isOnMusicBg;
    public bool isOnSound;
    public int countCoins;
    public List<int> listIdGun;
    public int level;
}