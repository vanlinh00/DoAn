using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUi : MonoBehaviour
{
    public Image healthBar;
    public void ChangeFillAmountHealth()
    {
        if(Random.RandomRange(1,7)==1)
        {
            healthBar.fillAmount = healthBar.fillAmount - 0.1f;
        }
    }
    private void OnEnable()
    {
        EventManager.HitPlayer += ChangeFillAmountHealth;
    }
    public void OnDisable()
    {
        EventManager.HitPlayer -= ChangeFillAmountHealth;
    }

}
