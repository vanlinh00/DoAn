using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject player;
    
    //PickUP
    public float distancePickUp;
    
    //Move
    public PlayerMovement playerMovement;
    
    //rotation
    public PlayerCam playerCam;
    
    // Gun
    public Gun gunPlayer;

    public Transform posDesMap;
    public float health;
    public bool isOnTrain;
    public float HpPlayer;
    public enum StatePlayer
    {
        Die,
        Living,
    }

    public StatePlayer statePlayer;

    private void Awake()
    {
        health = 1000;
        instance = this;
        statePlayer = StatePlayer.Living;
        //Die();
        DisableCursor();
    }
    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    //public void Shooting()
    //{
    //    gunPlayer.Shoot();
    //}
    //public void Damage(float DamagePlayer)
    //{
    //    health -= DamagePlayer;
    //  //  UiGamePlay.instance.UpdateHealthBarPlayer(health / 1000f);
    //    if(health<=0)
    //    {
    //        Die();
    //        Debug.Log("Player Die - End Game");
    //    }
    //}

    //public void Die()
    //{
    //    if (statePlayer == StatePlayer.Die)
    //        return;
    //    statePlayer = StatePlayer.Die;
    //    player.transform.DORotate(new Vector3(0, 0, 180), 1f, RotateMode.LocalAxisAdd);
    //    // .SetDelay(3f)
    //    // .OnComplete(() => transform.DORotate(new Vector3(0, 0, 180), 1, RotateMode.LocalAxisAdd)
    //    //     .SetDelay(1)
    //    //     .Play())
    //    // .Play();
    //}


    private void OnEnable()
    {
        EventManager.HitPlayer += Damage;
    }
    public void OnDisable()
    {
        EventManager.HitPlayer -= Damage;
    }
    public void Damage()
    {
        if (UnityEngine.Random.RandomRange(1, 7) == 3)
        {
            //  Debug.Log(HpPlayer);
            HpPlayer -= 100;
            UiController._instance.EnableHitZone();
            MainUi._instance.ChangeFillAmountHealth();
            UiController._instance.CountTimeHizone = 0f;
            if (HpPlayer <= 0)
            {
                GameManager._instance.gamePlay.EndGame();
                UiController._instance.ActiveEndGameUi();
                gameObject.SetActive(false);
            }
        }

    }


}