using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MainUi : Singleton<MainUi>
{
    public Image healthBar;
    public TextMeshProUGUI enemyTxt;
    public int TotalAmountEnemy;

    public Image GunImg;
    public TextMeshProUGUI nameGunTxt;
    public TextMeshProUGUI CountBulletTxt;
    public void ChangeFillAmountHealth()
    {
        //if(Random.RandomRange(1,7)==1)
        //{
            healthBar.fillAmount = healthBar.fillAmount - 0.1f;
   
       // }
    }
    private void OnEnable()
    {
        EventManager.EnemyDie += DisplayAmountEnemy;
    }
    private void OnDisable()
    {
        EventManager.EnemyDie -= DisplayAmountEnemy;
    }
    public void DisplayAmountEnemy()
    {
        TotalAmountEnemy--;
        enemyTxt.text = TotalAmountEnemy + "/" + 6;
        if(TotalAmountEnemy<=0)
        {
            Debug.Log("Win Game");
        }
    }

    public void LoadGunPlaying(Weapon weapon,bool IsFrag)
    {
        if(!IsFrag)
        {
            GunImg.sprite = Resources.Load<Sprite>("Image/Shop/Guns/" + weapon.idGun);
        }
        else
        {
            GunImg.sprite = Resources.Load<Sprite>("Image/Shop/Frag/" + 1);
        }

        //nameGunTxt.text
        CountBulletTxt.text = weapon._countBullet+ "/"+weapon._countTotalBullets;
    }

}
