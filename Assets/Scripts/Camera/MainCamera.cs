using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : Singleton<MainCamera>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void SetNormalMainCamera()
    {
        transform.localPosition = new Vector3(0, 3, 0);
    }
    public void SetMainCameraAWM()
    {
        transform.localPosition = new Vector3(0, 3, 6);
    }
}
