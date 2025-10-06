using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// メインメニューインターフェースで、オブジェクトを自動的に回転させる
/// </summary>
public class AutoRotation : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        this.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
