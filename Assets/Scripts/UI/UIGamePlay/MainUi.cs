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

}
