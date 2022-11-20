using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject _uiStore;
    [SerializeField] StoreManager _storeManager;
    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            if(_uiStore.activeSelf)
            {
                CloseStore();
            }
            else
            {
                OpenStore();
            }
           
        }
    }
    public void OpenStore()
    {
        _uiStore.SetActive(true);
        GameState.stateGame = StateGame.OpenStore;
        EnableCursor();
    }
    public void CloseStore()
    {
        _uiStore.SetActive(false);
        GameState.stateGame = StateGame.Playing;
        DisableCursor();
    }
    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
