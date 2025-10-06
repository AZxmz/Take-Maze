using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// さまざまなパネルを制御し、パネルの基本機能を管理します
/// </summary>
public class PanelController<T> : MonoBehaviour where T : class
{
    
    private static T instance;
    public static T Instance => instance;
    void Awake()
    {
        instance = this as T;
    }


    public virtual void Show()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
