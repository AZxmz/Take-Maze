using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ランダム武器報酬
/// </summary>
public class WeaponReward : MonoBehaviour
{
    public GameObject[] weapons;

    public GameObject getEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //武器ライブラリからランダムに武器を選択する
            int index = Random.Range(0, weapons.Length);           
            PlayerTank player = other.GetComponent<PlayerTank>();
            player.ChangeWeapon(weapons[index]);

            GameObject effect = Instantiate(getEffect, this.transform.position, this.transform.rotation);
            AudioSource audioSource = effect.GetComponent<AudioSource>();
            audioSource.volume = DataManager.Instance.musicData.soundValue;
            audioSource.mute = !DataManager.Instance.musicData.isOnSound;

            Destroy(this.gameObject);

        }
    }

}
