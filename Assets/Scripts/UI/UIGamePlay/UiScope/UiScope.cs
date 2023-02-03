using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScope : Singleton<UiScope>
{
    public GameObject Scope;
    public GameObject ScopeAWM;
    protected override void Awake()
    {
        base.Awake();
        SetNormalScope();
    }
    public void SetNormalScope()
    {
        Scope.SetActive(true);
        ScopeAWM.SetActive(false);
        MainCamera._instance.SetNormalMainCamera();
    }
    public void SetScopeAWM()
    {
        Scope.SetActive(false);
        ScopeAWM.SetActive(true);
        MainCamera._instance.SetMainCameraAWM();
    }
}
