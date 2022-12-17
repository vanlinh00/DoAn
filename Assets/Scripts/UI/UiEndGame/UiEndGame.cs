using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UiEndGame : MonoBehaviour
{
    [SerializeField] Button ComeBackBtn;
    [SerializeField] CanvasGroup _canvasGr;
    private void Awake()
    {
        ComeBackBtn.onClick.AddListener(LoadMenu);
    }
    public void Show()
    {
        _canvasGr.alpha = 0;
        DOTween.To(() => _canvasGr.alpha, value => _canvasGr.alpha = value, 1, 0.5f);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
