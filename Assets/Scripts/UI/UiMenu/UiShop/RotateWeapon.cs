using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    float yRotation;
    float speed = 50f;
    void Update()
    {
        transform.Rotate(0,yRotation+ Time.deltaTime* speed, 0);
    }
}
