using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵とプレイヤーの共通の属性と機能を管理するタンク基本クラス
/// </summary>
public class TankBase : MonoBehaviour
{
    public int attack;
    public int defence;
    public int currentHP;
    public int maxHP;

    public float moveSpeed = 10;
    public float rotateSpeed = 100;
    public float headRotateSpeed = 1000;

    public GameObject headObject;

    public GameObject deadEffect;

    public virtual void Fire()
    {

    }

    public virtual void GetInjured(TankBase attackTank)
    {
        int damage = attackTank.attack - this.defence;
        if (damage <= 0)
        {
            return;
        }
        else
        {
            this.currentHP -= damage;
        }
        if (this.currentHP <= 0)
        {
            this.currentHP = 0;
            Dead();
        }
    }

    public virtual void Dead()
    {
        Destroy(this.gameObject);
        if (deadEffect != null)
        {
            //死の影響は死後に現れる
            GameObject effectObject = Instantiate(deadEffect, this.transform.position, this.transform.rotation);
            AudioSource audioSource = effectObject.GetComponent<AudioSource>();
            //データが保存されているボリュームを読み取る
            audioSource.volume = DataManager.Instance.musicData.soundValue;
            //データストアに保存されているサウンド効果のステータスを読み取る
            audioSource.mute = !DataManager.Instance.musicData.isOnSound;
            audioSource.Play();
        }


    }

}
