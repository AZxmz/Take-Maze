using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ライブカメラのミニマップ
/// </summary>
public class CameraMap : MonoBehaviour
{
    public Transform targetTransform;
    private Vector3 position;

    [SerializeField] private float height;


    void LateUpdate()
    {
        if (targetTransform != null)
        {
            position.x = targetTransform.position.x;
            position.z = targetTransform.position.z;
            //カメラの高さ
            position.y = height;
        }
        this.transform.position = position;
    }
}
