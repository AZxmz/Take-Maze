using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//基本属性の報酬
public enum E_RewardType
{
    HP,
    maxHP,
    Attack,
    Defemce,
}
/// <summary>
/// 関連基本属性の報酬管理
/// </summary>
public class Prpperity : MonoBehaviour
{
    public E_RewardType rewardType;

    public GameObject getEffect;

    public int changeValue;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTank player = other.GetComponent<PlayerTank>();
            switch (rewardType)
            {
                case E_RewardType.HP:
                    player.currentHP += changeValue;
                    if (player.currentHP > player.maxHP)
                    {
                        player.currentHP = player.maxHP;
                    }
                    GamePanel.Instance.UpdateHp(player.currentHP, player.maxHP);
                    break;
                case E_RewardType.maxHP:
                    player.maxHP += changeValue;
                    GamePanel.Instance.UpdateHp(player.currentHP, player.maxHP);
                    break;
                case E_RewardType.Attack:
                    player.attack += changeValue;
                    break;
                case E_RewardType.Defemce:
                    player.defence += changeValue;
                    break;

            }

            GameObject effect = Instantiate(getEffect, this.transform.position, this.transform.rotation);
            AudioSource audioSource = effect.GetComponent<AudioSource>();
            audioSource.volume = DataManager.Instance.musicData.soundValue;
            audioSource.mute = !DataManager.Instance.musicData.isOnSound;
        }
        Destroy(this.gameObject);
    }
}
