using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 自動破棄: 過剰なメモリ使用を防止
/// </summary>
public class AutoDestory : MonoBehaviour
{
    [SerializeField] private float time = 2;
    void Start()
    {
        Destroy(this.gameObject, time);
    }


}
