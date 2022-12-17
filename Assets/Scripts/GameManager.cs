using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Awake()
    {
        if(this!=null)
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
    private void Start()
    {
        GameState.stateGame = StateGame.Playing;
        UpdateCore();
    }
    void UpdateCore()
    {
        DataPlayer.UpdateAmountCoins(20000);
    }
    private void Update()
    {
        if (Input.GetKeyDown("u"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
    }
}
