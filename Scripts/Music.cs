using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// バックグラウンドミュージックの管理
/// </summary>
public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    private static Music instance = new Music();

    public static Music Instance => instance;

    void Awake()
    {
        instance = this;
        ChangeState(DataManager.Instance.musicData.isOnMusic);
        ChangeMusicValue(DataManager.Instance.musicData.musicValue);
    }

    public void ChangeMusicValue(float value)
    {
        audioSource.volume = value;
    }

    public void ChangeState(bool isOn)
    {
        audioSource.mute = !isOn;
    }


}
